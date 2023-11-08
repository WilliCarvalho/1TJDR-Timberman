using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private UIGameOver gameOverScreen;

    private void Awake()
    {
        playButton.onClick.AddListener(GoToGameScene);
        gameOverScreen.gameObject.SetActive(false);
    }
    
    private void GoToGameScene()
    {
        GameSystem.instance.PlaySFXAudioByType(SFXAudioType.OnClick);
        GameSystem.instance.PlayGame();
    }

    public void UpdateGameScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
    

    
}
