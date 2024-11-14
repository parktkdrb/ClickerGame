using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public ButtonManger buttonManger;
    public BackGroundMove BackGroundMove;
    public ScoreText ScoreText;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.UIManager = this;
        buttonManger = GetComponent<ButtonManger>();
        ScoreText = GetComponent<ScoreText>();

    }
}
