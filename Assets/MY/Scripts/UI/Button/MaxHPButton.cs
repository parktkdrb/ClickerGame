using System.Numerics;
using TMPro;
using UnityEngine;

public class MaxHPButton : ButtonManger
{
    [SerializeField] private BigInteger Cost = 10;
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
            GameManager.Instance.Player.maxHP += (int)Cost; 
            GameManager.Instance.Player.HPBarUpdate();
            GameManager.Instance.UIManager.ScoreText.TextScore();
            UpdateButtonText();
        }
        else
        {
            UnityEngine.Debug.Log("코스트가 부족합니다.");
        }
    }
    private void UpdateButtonText()
    {
        // 버튼의 텍스트를 현재 비용으로 업데이트
        buttonText.text = $"최대 HP 상승\n비용: {Cost}";
    }
}