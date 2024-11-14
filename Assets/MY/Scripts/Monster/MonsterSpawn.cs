using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] public GameObject spawnMonster;
    [SerializeField] public GameObject MonsterFill;
    //1. 몬스터 생성
    //2. 몬스터 왼쪽으로 이동(target 위치로) -> 몬스터 스크립트
    //3. 몬스터가 target 위치로 올시 정지 -> 몬스터 스크립트
    //4. 배경 정지(stopcoroutin), 플레이어 Attack 애니메이션
    //5. 데미지 처리 : 오브젝터블 스크립트?, 그냥 플레이어가 5번 때리면 사망처리?
    //6. 버튼은 어카지? 
    private void Start()
    {
        InsMonster();
    }
    public void InsMonster()
    {
        // 풀에서 오브젝트를 가져옴
        spawnMonster = GameManager.Instance.objectPool.MonsterGet();
        spawnMonster.transform.position = gameObject.transform.position; // 현재 오브젝트 위치로 이동
    }
}
