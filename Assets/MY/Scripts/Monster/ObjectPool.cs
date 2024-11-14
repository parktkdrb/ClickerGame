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
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
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
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.
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
                Debug.Log("���� ������ ������Ʈ�� �����ϴ�.");
            }
        }
        return obj;
    }
    public GameObject EffectGet()
    {
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.
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
                Debug.Log("���� ������ ������Ʈ�� �����ϴ�.");
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
            Debug.Log("Monster Ŭ���� ������Ʈ�� ����.");
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