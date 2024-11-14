using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamage//monster랑 같이 Character로 묶을 수 있을 듯
{
    public PlayerOS playerOS;
    public int maxHP;
    public int HP;
    public int damage;
    public float AttackSpeed = 2f;
    private Animator animator;
    public Image hpFill;
    [SerializeField] public LayerMask layerMask;
    public Button button;
    // Start is called before the first frame update
    void Awake()
    {
        GameManager.Instance.Player = this;
        button.enabled = false;
        maxHP = playerOS.HP;
        HP = maxHP;
        damage = playerOS.Damage;
        animator = GetComponent<Animator>();
    }

    public void Hit(int damage)
    {
        HP -= damage;
        HPBarUpdate();
        if (HP <= 0)
        {
            Die();
        }
    }
    public void HPBarUpdate()
    {
        hpFill.fillAmount = (float)HP / maxHP;
    }
    public void Die()
    {
        HP = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            button.enabled = true;
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Attack", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            button.enabled = false;
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", false);
        }
        
    }
    public void Attack()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Attack", true);

        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector3.right, 1f, layerMask);
        if (hit.collider != null)  // 먼저 hit.collider가 null인지 확인
        {
            if (hit.collider.TryGetComponent<IDamage>(out IDamage hitDamage))
            {
                hitDamage.Hit(damage);
            }
            else
            {
                Debug.Log("충돌한 객체가 IDamage를 구현하지 않았습니다.");
            }
        }
        else
        {
            Debug.Log("몬스터가 존재하지 않습니다.");
        }
    }
    public void StopAttack()
    {
        animator.SetBool("Attack", false);
        animator.SetBool("Idle", true);
    }


}
