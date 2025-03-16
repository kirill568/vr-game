using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private bool isActive = false; // Флаг активности

    public void ActivateSystem()
    {
        isActive = true;
        score = 0;
        UpdateScoreDisplay();
    }

    public void AddScore(int points)
    {
        if (!isActive) return; // Игнорируем если система неактивна

        score += points;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}