using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Button replayButton;

    private void Awake()
    {
        replayButton.onClick.AddListener(PlayAgain);
        GameSystem.instance.SetGameOverUI(this);
        this.gameObject.SetActive(false);
    }

    private void PlayAgain()
    {
        GameSystem.instance.PlaySFXAudioByType(SFXAudioType.OnClick);
        GameSystem.instance.PlayGame();
    }

    public void UpdateScoreTexts(int currentScore, int bestScore)
    {
        currentScoreText.text = currentScore.ToString();
        bestScoreText.text = bestScore.ToString();
    }
    public void ShowGameOverUI(int currentScore, int bestScore)
    {
        this.gameObject.SetActive(true);
        this.UpdateScoreTexts(currentScore, bestScore);
    }
}
