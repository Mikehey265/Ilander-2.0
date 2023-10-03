using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Action OnGamePaused;
    public static Action OnGameUnpaused;

    private GameControls _gameControls;
    private static bool _isGamePaused;

    private void Awake()
    {
        _gameControls = new GameControls();
    }

    private void Start()
    {
        _isGamePaused = false;
        _gameControls.Pause.PauseAction.performed += PauseAction;
    }

    private void OnEnable()
    {
        _gameControls.Pause.Enable();
    }

    private void OnDisable()
    {
        _gameControls.Pause.Disable();
    }

    public static void TogglePauseMenu()
    {
        _isGamePaused = !_isGamePaused;
        if (_isGamePaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke();
        }
        else
        {
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke();
        }
    }
    
    private void PauseAction(InputAction.CallbackContext context)
    {
        TogglePauseMenu();
    }
}
