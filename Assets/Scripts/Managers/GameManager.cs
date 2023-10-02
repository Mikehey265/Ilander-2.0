using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static Action OnRocketHit;
    public static Action OnRocketCrashed;
    public static Action OnRocketFinished;
    public static Action OnStateChanged;

    private enum State
    {
        CountdownToStart,
        GamePlaying,
        GameOver,
        GameFinished,
    }

    private State _state;

    private float _countdownToStartTimer = 3f;
    private float _gamePlayingTimer;
    private float _countdownToReloadLevel = 3f;
    private float _countdownToLoadNextLevel;

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
                break;
            case State.GameFinished:
                break;
            case State.GameOver:
                _countdownToReloadLevel -= Time.deltaTime;
                if (_countdownToReloadLevel < 0f)
                {
                    SceneLoader.Load(SceneLoader.Scene.TestScene);
                }
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

    public float GetCountdownToStartTimer()
    {
        return _countdownToStartTimer;
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