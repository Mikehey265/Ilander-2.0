using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(InputManager.TogglePauseMenu );
        
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneLoader.Load(SceneLoader.Scene.MainMenu);
        } );
    }

    private void Start()
    {
        InputManager.OnGamePaused += GamePaused;
        InputManager.OnGameUnpaused += GameUnpaused;
        
        Hide();
    }

    private void OnDestroy()
    {
        InputManager.OnGamePaused -= GamePaused;
        InputManager.OnGameUnpaused -= GameUnpaused;
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