using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private GameObject MenuPanel;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ScoreText != null)
            ScoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {   
        if (ScoreText != null)
            ScoreText.text = $"Score: {score}";
    }

    public void ShowMenu(bool isVisible)
    {
        MenuPanel.SetActive(isVisible);

        Cursor.lockState = isVisible ?
            CursorLockMode.None:
            CursorLockMode.Locked;
        Cursor.visible = isVisible;
    }

    /*public void IncrementScore()
    {
        score++;
    }*/
    public void SetScore(int newScore)
    {
        score = newScore;
    }
}   

