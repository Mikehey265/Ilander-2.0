using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private const string PLAYER_PREFS_HIGHSCORE = "Score_";

    private int _numberOfHits;
    private int _finalScore;
    private int _highScore;

    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey(PLAYER_PREFS_HIGHSCORE + SceneLoader.GetCurrentScene()))
        {
            _highScore = PlayerPrefs.GetInt(PLAYER_PREFS_HIGHSCORE + SceneLoader.GetCurrentScene());
        }
    }

    private void Start()
    {
        GameManager.OnRocketHit += UpdateNumberOfHits;
        GameManager.OnScorePanelActivated += Score;
        
        _numberOfHits = 0;
    }

    public int GetFinalScore()
    {
        return _finalScore;
    }

    public bool IsHighScorePresent()
    {
        return PlayerPrefs.HasKey(PLAYER_PREFS_HIGHSCORE + SceneLoader.GetCurrentScene());
    }

    public int GetHighScore()
    {
        return _highScore;
    }
    
    private void Score()
    {
        int finishedLevelTime = GameManager.Instance.GetFinishedLevelTime();
        
        if (_numberOfHits == 0)
        {
            _finalScore = 100 * 100 / finishedLevelTime;
        }
        else
        {
            _finalScore = 100 * (100 / finishedLevelTime) / (_numberOfHits + 1);
        }
    }

    public void SaveScore(SceneLoader.Scene scene)
    {
        if (PlayerPrefs.HasKey(PLAYER_PREFS_HIGHSCORE + scene))
        {
            if (_finalScore > PlayerPrefs.GetInt(PLAYER_PREFS_HIGHSCORE + scene))
            {
                _highScore = _finalScore;
                PlayerPrefs.SetInt(PLAYER_PREFS_HIGHSCORE + scene, _highScore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            if (_finalScore > _highScore)
            {
                _highScore = _finalScore;
                PlayerPrefs.SetInt(PLAYER_PREFS_HIGHSCORE + scene, _highScore);
                PlayerPrefs.Save();
            }
        }
    }
    
    private void UpdateNumberOfHits()
    {
        _numberOfHits++;
    }
}
