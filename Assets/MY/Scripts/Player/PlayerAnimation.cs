using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BackGroundMove backGroundMove;
    private void Start()
    {
        animator = GetComponent<Animator>();
        backGroundMove = GameManager.Instance.gameObject.GetComponent<BackGroundMove>();

        animator.SetBool("Run", true);
    }

}
