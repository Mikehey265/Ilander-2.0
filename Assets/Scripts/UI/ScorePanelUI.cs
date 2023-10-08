using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelUI : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button restartLevelButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.GetCurrentScene() + 1);
        } );
        
        restartLevelButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.GetCurrentScene());
        } );
        
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.MainMenu);
        } );
    }

    private void Start()
    {
        GameManager.OnScorePanelActivated += UpdateScorePanel;
        Hide();
    }

    private void OnDestroy()
    {
        GameManager.OnScorePanelActivated -= UpdateScorePanel;
    }

    private void UpdateScorePanel()
    {
        timeText.text = "Your time: " + GameManager.Instance.GetFinishedLevelTime() + "s";
        scoreText.text = "Your score: " + ScoreManager.Instance.GetFinalScore();

        if (ScoreManager.Instance.IsHighScorePresent())
        {
            highScoreText.text = "Current high score: " + ScoreManager.Instance.GetHighScore();
        }
        else
        {
            highScoreText.text = "Current high score: 0";
        }
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
