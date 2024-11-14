using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHPBar : MonoBehaviour
{
    private Monster monster;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponentInParent<Monster>();
        image = GetComponentInChildren<Image>();

        if (monster == null)
        {
            Debug.Log("Monster component not found in parent.");
        }
        if (image == null)
        {
            Debug.Log("Image component not found in children.");
        }
    }

    void Update()
    {
        if (monster != null && image != null)
        {
            image.fillAmount = (float)monster.hp / monster.maxHP;
        }
    }
}
