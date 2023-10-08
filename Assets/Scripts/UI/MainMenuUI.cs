using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button resetHighScoresButton;
    [SerializeField] private TextMeshProUGUI level1HighScoreText;
    [SerializeField] private TextMeshProUGUI level2HighScoreText;
    [SerializeField] private TextMeshProUGUI level3HighScoreText;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.Level1);
        } );
        
        resetHighScoresButton.onClick.AddListener(() =>
        {
            PlayerPrefs.DeleteAll();
        } );
        
        quitButton.onClick.AddListener(Application.Quit);

        Time.timeScale = 1f;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Score_" + SceneLoader.Scene.Level1))
        {
            level1HighScoreText.text = "Level1: " + PlayerPrefs.GetInt("Score_" + SceneLoader.Scene.Level1);
        }
        if (PlayerPrefs.HasKey("Score_" + SceneLoader.Scene.Level2))
        {
            level2HighScoreText.text = "Level2: " + PlayerPrefs.GetInt("Score_" + SceneLoader.Scene.Level2);
        }
        if (PlayerPrefs.HasKey("Score_" + SceneLoader.Scene.Level3))
        {
            level3HighScoreText.text = "Level3: " + PlayerPrefs.GetInt("Score_" + SceneLoader.Scene.Level3);
        }
    }
}
