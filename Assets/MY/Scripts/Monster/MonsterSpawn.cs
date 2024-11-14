using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] public GameObject spawnMonster;
    [SerializeField] public GameObject MonsterFill;
    //1. ���� ����
    //2. ���� �������� �̵�(target ��ġ��) -> ���� ��ũ��Ʈ
    //3. ���Ͱ� target ��ġ�� �ý� ���� -> ���� ��ũ��Ʈ
    //4. ��� ����(stopcoroutin), �÷��̾� Attack �ִϸ��̼�
    //5. ������ ó�� : �������ͺ� ��ũ��Ʈ?, �׳� �÷��̾ 5�� ������ ���ó��?
    //6. ��ư�� ��ī��? 
    private void Start()
    {
        InsMonster();
    }
    public void InsMonster()
    {
        // Ǯ���� ������Ʈ�� ������
        spawnMonster = GameManager.Instance.objectPool.MonsterGet();
        spawnMonster.transform.position = gameObject.transform.position; // ���� ������Ʈ ��ġ�� �̵�
    }
}
