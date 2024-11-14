using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamage//monster�� ���� Character�� ���� �� ���� ��
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
        if (hit.collider != null)  // ���� hit.collider�� null���� Ȯ��
        {
            if (hit.collider.TryGetComponent<IDamage>(out IDamage hitDamage))
            {
                hitDamage.Hit(damage);
            }
            else
            {
                Debug.Log("�浹�� ��ü�� IDamage�� �������� �ʾҽ��ϴ�.");
            }
        }
        else
        {
            Debug.Log("���Ͱ� �������� �ʽ��ϴ�.");
        }
    }
    public void StopAttack()
    {
        animator.SetBool("Attack", false);
        animator.SetBool("Idle", true);
    }


}
