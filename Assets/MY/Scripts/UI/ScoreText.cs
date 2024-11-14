using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoretext;

    public void TextScore()
    {
        scoretext.text = GameManager.Instance.Score.ToString();
    }
}
