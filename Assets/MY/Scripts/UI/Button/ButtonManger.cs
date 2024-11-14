using System.Collections;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonManger : MonoBehaviour
{
    [SerializeField] public int clickScore = 1;
    [SerializeField] public ScoreText scoreText;
    [SerializeField] protected TextMeshProUGUI buttonText;
    protected virtual void Start()
    {
        scoreText = GetComponent<ScoreText>();
    }
    public virtual void ClickEvent()
    {
        GameManager.Instance.SoundManager.MainSound();
        GameManager.Instance.Score += clickScore;
        scoreText.TextScore();
    }
}
