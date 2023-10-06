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
    private int _numberOfHits;
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
        OnRocketHit += UpdateNumberOfHits;
        
        _gamePlayingTimer = 0f;
        _numberOfHits = 0;
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
                Score();
                _countdownToShowScorePanel -= Time.deltaTime;
                if (_countdownToShowScorePanel < 0f)
                {
                    _state = State.ScoreWindow;
                    // SceneLoader.Load(SceneLoader.GetCurrentScene() + 1);
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

    public int GetFinalScore()
    {
        return _finalScore;
    }

    public int GetFinishedLevelTime()
    {
        return _finishedLevelTime;
    }

    private void Score()
    {
        if (_numberOfHits == 0)
        {
            _finalScore = _finishedLevelTime * 10;
        }
        else
        {
            _finalScore = _finishedLevelTime / (_numberOfHits + 1) * 10;
        }
        Debug.Log("Time: " + _finishedLevelTime);
        Debug.Log("Number Of Hits: " + _numberOfHits);
        Debug.Log("Final Score: " + _finalScore);
    }

    private void UpdateNumberOfHits()
    {
        _numberOfHits++;
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
