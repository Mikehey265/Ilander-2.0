using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action OnRocketHit;
    public static Action OnRocketCrashed;
    public static Action OnRocketFinished;
    public static Action OnStateChanged;
    public static Action OnScorePanelActivated;

    private enum State
    {
        CountdownToStart,
        GamePlaying,
        GameOver,
        GameFinished,
        ScoreWindow,
    }

    private State _state;

    private float _countdownToStartTimer = 3f;
    private float _countdownToReloadLevel = 3f;
    private float _countdownToShowScorePanel = 2f;
    private float _gamePlayingTimer;
    private int _finishedLevelTime;
    private int _finalScore;

    private void Awake()
    {
        Instance = this;
        
        _state = State.CountdownToStart;
        OnRocketCrashed += RocketCrashed;
        OnRocketFinished += RocketFinished;
    }

    private void Start()
    {
        OnStateChanged?.Invoke();
        
        _gamePlayingTimer = 0f;
    }

    private void Update()
    {
        switch (_state)
        {
            case State.CountdownToStart:
                _countdownToStartTimer -= Time.deltaTime;
                if (_countdownToStartTimer < 0f)
                {
                    _state = State.GamePlaying;
                    OnStateChanged?.Invoke();
                }
                break;
            case State.GamePlaying:
                _gamePlayingTimer += Time.deltaTime;
                break;
            case State.GameOver:
                _countdownToReloadLevel -= Time.deltaTime;
                if (_countdownToReloadLevel < 0f)
                {
                    SceneLoader.Load(SceneLoader.GetCurrentScene());
                }
                break;
            case State.GameFinished:
                _finishedLevelTime = (int)_gamePlayingTimer;
                _countdownToShowScorePanel -= Time.deltaTime;
                if (_countdownToShowScorePanel < 0f)
                {
                    _state = State.ScoreWindow;
                }
                break;
            case State.ScoreWindow:
                OnScorePanelActivated?.Invoke();
                break;
        }
    }
    
    public bool IsGamePlaying()
    {
        return _state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive()
    {
        return _state == State.CountdownToStart;
    }

    public bool IsScoreWindowOpen()
    {
        return _state == State.ScoreWindow;
    }

    public float GetCountdownToStartTimer()
    {
        return _countdownToStartTimer;
    }

    public int GetFinishedLevelTime()
    {
        return _finishedLevelTime;
    }

    private void RocketCrashed()
    {
        _state = State.GameOver;
    }

    private void RocketFinished()
    {
        _state = State.GameFinished;
    }
}
