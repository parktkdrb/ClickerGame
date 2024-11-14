using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class BackGroundMove : MonoBehaviour
{
    [SerializeField] private GameObject backGround1;
    [SerializeField] private GameObject backGround2;
    [SerializeField] private float speed;

    public bool MoveBackground = true;

    private void Start()
    {
        GameManager.Instance.UIManager.BackGroundMove = this;
    }
    private void Update()
    {
        if (MoveBackground)
        {
            backGround1.transform.Translate(Vector2.left * speed * Time.deltaTime);
            backGround2.transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (backGround1.transform.position.x <= -214f)
            {
                backGround1.transform.position = new Vector3(233f, -9.87f, 99.11f);
            }

            if (backGround2.transform.position.x <= -214f)
            {
                backGround2.transform.position = new Vector3(233f, -9.87f, 99.11f);
            }

        }
    }
}
