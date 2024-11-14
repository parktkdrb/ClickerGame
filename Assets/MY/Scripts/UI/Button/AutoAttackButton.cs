using System.Collections;
using System.Numerics;
using TMPro;
using UnityEngine;

public class AutoAttackButton : ButtonManger
{
    [SerializeField] private BigInteger Cost = 20;
    [SerializeField] private BigInteger AutoScore = 0;
    private Coroutine autoCoroutine;
    protected override void Start()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateButtonText();
    }
    public override void ClickEvent()
    {
        if (GameManager.Instance.Score >= Cost)
        {
            GameManager.Instance.SoundManager.UpgradeSound();
            GameManager.Instance.Score -= Cost;
            Cost *= 2;
            AutoScore += 2;
            if (autoCoroutine == null)
            {
                autoCoroutine = StartCoroutine(Auto());
            }
            GameManager.Instance.UIManager.ScoreText.TextScore();
            UpdateButtonText();
        }
        else
        {
            Debug.Log("코스트가 부족합니다.");
        }
    }
    private void UpdateButtonText()
    {
        // 버튼의 텍스트를 현재 비용으로 업데이트
        buttonText.text = $"자동 클릭\n비용: {Cost}";
    }
    public IEnumerator Auto()
    {
        GameManager.Instance.Score += AutoScore;
        GameManager.Instance.UIManager.ScoreText.TextScore();
        yield return new WaitForSeconds(2f);
        StartCoroutine(Auto());
    }
}
