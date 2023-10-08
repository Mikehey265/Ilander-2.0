using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private const string PLAYER_PREFS_HIGHSCORE = "Score";

    private int _numberOfHits;
    private int _finalScore;
    private int _highScore;

    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey(PLAYER_PREFS_HIGHSCORE))
        {
            _highScore = PlayerPrefs.GetInt(PLAYER_PREFS_HIGHSCORE);
        }
    }

    private void Start()
    {
        GameManager.OnRocketHit += UpdateNumberOfHits;
        GameManager.OnScorePanelActivated += SaveScore;
        
        _numberOfHits = 0;
    }

    private void Update()
    {
        if (GameManager.Instance.IsScoreWindowOpen())
        {
            Score();
        }
    }
    
    public int GetFinalScore()
    {
        return _finalScore;
    }

    public bool IsHighScorePresent()
    {
        return PlayerPrefs.HasKey(PLAYER_PREFS_HIGHSCORE);
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
            _finalScore = finishedLevelTime * 10;
        }
        else
        {
            _finalScore = finishedLevelTime / (_numberOfHits + 1) * 10;
        }
        
        Debug.Log("Time: " + finishedLevelTime);
        Debug.Log("Number Of Hits: " + _numberOfHits);
        Debug.Log("Final Score: " + _finalScore);
    }

    private void SaveScore()
    {
        if (PlayerPrefs.HasKey(PLAYER_PREFS_HIGHSCORE))
        {
            if (_finalScore > PlayerPrefs.GetInt(PLAYER_PREFS_HIGHSCORE))
            {
                _highScore = _finalScore;
                PlayerPrefs.SetInt(PLAYER_PREFS_HIGHSCORE, _highScore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            if (_finalScore > _highScore)
            {
                _highScore = _finalScore;
                PlayerPrefs.SetInt(PLAYER_PREFS_HIGHSCORE, _highScore);
                PlayerPrefs.Save();
            }
        }
    }
    
    private void UpdateNumberOfHits()
    {
        _numberOfHits++;
    }
}
