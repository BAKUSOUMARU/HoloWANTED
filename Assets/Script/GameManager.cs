using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public StageManager stageManager;
    public TMP_Text scoreText;
    public TMP_Text levelText;
    private int currentLevel = 1;
    public int initialCharacterCount = 3;
    private int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        score = 0;
        currentLevel = 1;
        UpdateScoreDisplay();
        UpdateLevelDisplay();
        stageManager.SetupStage(currentLevel, initialCharacterCount);
    }

    public void OnCharacterSelected(bool isCorrect)
    {
        if (isCorrect)
        {
            score++;
            UpdateScoreDisplay();
            currentLevel++;
            UpdateLevelDisplay();
            stageManager.SetupStage(currentLevel, initialCharacterCount);
        }
        else
        {
            Debug.Log("Game Over");
            ResetGame();
        }
    }

    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateLevelDisplay()
    {
        levelText.text = "Level: " + currentLevel.ToString();
    }
    
  
}