using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int currentScore = 0;

    [Header("UI (assign one)")]
    public Text scoreText;
    public TextMeshProUGUI tmpScoreText;

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

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (tmpScoreText != null)
            tmpScoreText.text = currentScore.ToString();
        else if (scoreText != null)
            scoreText.text = currentScore.ToString();
    }
}
