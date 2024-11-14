using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
public class ObjectPool : MonoBehaviour
{
    public GameObject[] prefab;
    public GameObject effect;
    public GameObject objectPoolMonsterParent;
    public GameObject objectPoolEffectParent;
    private List<GameObject> Monsterpool = new List<GameObject>();
    private List<GameObject> Effectpool = new List<GameObject>();
    private int effectPoolSize = 300;
    void Awake()
    {
        // 게임오브젝트를 deactive한다.
        for (int i = 0; i < prefab.Length; i++)
        {
            GameObject insObj = Instantiate(prefab[i]);
            insObj.transform.SetParent(objectPoolMonsterParent.transform);
            insObj.SetActive(false);
            Monsterpool.Add(insObj);
        }
        for (int i = 0; i < effectPoolSize; i++)
        {
            GameObject insObj = Instantiate(effect);
            insObj.transform.SetParent(objectPoolEffectParent.transform);
            insObj.SetActive(false);
            Effectpool.Add(insObj);
        }
    }

    public GameObject MonsterGet()
    {
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
        GameObject obj = null;
        for (int i = 0; i < Monsterpool.Count; i++)
        {
            if (!Monsterpool[i].activeSelf)
            {

                obj = Monsterpool[i];
                obj.SetActive(true);
                Monsterpool.Remove(Monsterpool[i]);
                break;
            }
            else
            {
                Debug.Log("생성 가능한 오브젝트가 없습니다.");
            }
        }
        return obj;
    }
    public GameObject EffectGet()
    {
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
        GameObject obj = null;
        for (int i = 0; i < effectPoolSize; i++)
        {
            if (!Effectpool[i].activeSelf)
            {

                obj = Effectpool[i];
                obj.SetActive(true);
                Effectpool.Remove(Effectpool[i]);
                break;
            }
            else
            {
                Debug.Log("생성 가능한 오브젝트가 없습니다.");
            }
        }
        return obj;
    }

    public void MonsterRelease(GameObject obj)
    {
        if (obj.TryGetComponent<Monster>(out Monster monster))
        {
            GameManager.Instance.Score += monster.monsterOS.reward;
            GameManager.Instance.UIManager.ScoreText.TextScore();
        }
        else
        {
            Debug.Log("Monster 클래스 컴포넌트가 없음.");
        }
        obj.SetActive(false);
        Monsterpool.Add(obj);
    }
    public void EffectRelease(GameObject obj)
    {
        obj.SetActive(false);
        Effectpool.Add(obj);
    }
}