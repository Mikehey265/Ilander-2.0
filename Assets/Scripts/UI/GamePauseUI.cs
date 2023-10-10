using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(PauseMenu.TogglePauseMenu );
        
        restartButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.GetCurrentScene());
            Time.timeScale = 1f;
        } );
        
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.MainMenu);
        } );
    }

    private void Start()
    {
        PauseMenu.OnGamePaused += GamePaused;
        PauseMenu.OnGameUnpaused += GameUnpaused;
        
        Hide();
    }

    private void OnDestroy()
    {
        PauseMenu.OnGamePaused -= GamePaused;
        PauseMenu.OnGameUnpaused -= GameUnpaused;
    }

    private void GamePaused()
    {
        Show();
    }

    private void GameUnpaused()
    {
        Hide();
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
