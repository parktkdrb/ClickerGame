using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public interface IDamage
{
    public void Hit(int damage);
    public void Die();
}

public class Monster : MonoBehaviour, IDamage
{
    [SerializeField] public MonsterOS monsterOS;
    [SerializeField] public int maxHP;
    [SerializeField] public float hp;
    [SerializeField] public int speed;
    [SerializeField] private Transform targetPos;
    [SerializeField] public LayerMask layerMask;
    [SerializeField] private MonsterSpawn monsterSpawn;
    [SerializeField] private GameObject MonsterFill;
    public bool AttackCheck = false;

    // Start is called before the first frame update
    private void OnEnable()
    {
        ResetMonster(); // 몬스터 초기화
    }
    private void ResetMonster()
    {
        maxHP = monsterOS.HP;
        hp = maxHP;
    }
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);

    }
    public void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        hp = 0;
        GameManager.Instance.UIManager.BackGroundMove.MoveBackground = true;
        monsterSpawn.InsMonster(); // 다음 몬스터 스폰
        GameManager.Instance.objectPool.MonsterRelease(gameObject); // 오브젝트 풀로 반환
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.UIManager.BackGroundMove.MoveBackground = false;
            StartCoroutine(Attack());
        }
    }
    public IEnumerator Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector3.left, 1f, layerMask);
        IDamage hitDamage = hit.collider.GetComponent<IDamage>();
        if (hitDamage != null)
        {
            hitDamage.Hit(monsterOS.Damage);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Attack());
    }
}
