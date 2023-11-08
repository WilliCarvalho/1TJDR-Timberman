using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    public static GameSystem instance;
    [HideInInspector] public InputManager inputManager;
    [SerializeField] private AudioSystem audioSystem;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private TrunkPool trunkPool;
    [SerializeField] private UIGameOver gameOverUI;

    private int gameScore;
    private int bestScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        inputManager = new InputManager();
        inputManager.OnHit += IncreaseScore;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        PlayEnviromentAudioByType(EnviromentAudioType.Menu);
    }

    public void PlayEnviromentAudioByType(EnviromentAudioType audioType)
    {
        audioSystem.PlayEnviromentAudioByType(audioType);
    }

    public void PlaySFXAudioByType(SFXAudioType audioType)
    {
        audioSystem.PlaySFXAudioByType(audioType);
    }

    //Essa função recebendo um vector2 É UM ERRO NA ARQUITETURA DO PROJETO
    private void IncreaseScore(Vector2 touchPos)
    {
        gameScore++;
        uiManager.UpdateGameScore(gameScore);
    }

    public void TrunkHit()
    {
        trunkPool.TrunkHit();
    }

    public void PlayGame()
    {        
        SceneManager.LoadScene("sGame");
        PlayEnviromentAudioByType(EnviromentAudioType.Gameplay);
    }

    public void GameOver()
    {
        inputManager.DisableInput();
        if(gameScore > bestScore)
        {
            bestScore = gameScore;
        }
        gameOverUI.ShowGameOverUI(gameScore, bestScore);
        Debug.LogError("GAME OVER!!!");
    }

    public void SetTrunkPool(TrunkPool pool)
    {
        trunkPool = pool;
    }

    public void SetUIManager(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    public void SetGameOverUI(UIGameOver uiGameOver)
    {
        gameOverUI = uiGameOver;
    }
}
