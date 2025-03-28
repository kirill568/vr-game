using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class DummyTrigger : MonoBehaviour
{
    [Header("Game Setup")]
    [SerializeField] private GameObject[] targetDummies;
    [SerializeField] private ScoreManager scoreManager;

    [Header("UI Setup")]
    [SerializeField] private GameObject startPanel;
    [SerializeField] private TextMeshPro startText;
    [SerializeField] private TextMeshPro timerText;
    [SerializeField] private BoxCollider startPanelCollider;

    [Header("Game Settings")]
    [SerializeField] private float gameDuration = 60f;

    [Header("Audio Setup")]
    [SerializeField] private AudioSource tickSource;   // Отдельный источник для тика таймера
    [SerializeField] private AudioSource buttonSource; // Отдельный источник для звука кнопки

    private bool isActivated = false;
    private float timeRemaining;
    private bool gameEnded = false;

    private void Start()
    {
        timeRemaining = gameDuration;

        if (timerText != null)
        {
            timerText.text = $"Time: {Mathf.Ceil(timeRemaining)}";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameEnded)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (isActivated || !other.CompareTag("Player"))
            return;

        isActivated = true;

        // Воспроизводим звук кнопки через отдельный источник
        if (buttonSource != null)
        {
            buttonSource.Play();
        }

        scoreManager.ActivateSystem();

        if (targetDummies.Length > 0)
        {
            int randomIndex = Random.Range(0, targetDummies.Length);
            targetDummies[randomIndex].GetComponent<TargetDummy>().ActivateDummy();
        }

        if (startText != null)
        {
            startText.gameObject.SetActive(false);
        }

        if (startPanelCollider != null)
        {
            startPanelCollider.enabled = false;
        }

        StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= 1f; // Уменьшаем таймер на 1 секунду

            if (timerText != null)
            {
                timerText.text = $"Time: {Mathf.Ceil(timeRemaining)}";
            }

            // Воспроизводим звук тика таймера (если аудиоклип не играет)
            if (tickSource != null && !tickSource.isPlaying)
            {
                tickSource.Play();
            }

            yield return new WaitForSeconds(1f); // Ждём 1 секунду перед следующим тиком
        }

        EndGame();
    }


    private void EndGame()
    {
        if (startText != null)
        {
            startText.gameObject.SetActive(true);
            startText.text = "Time is out! Please enter in to the platform again to restart the game.";
        }

        if (startPanelCollider != null)
        {
            startPanelCollider.enabled = true;
        }

        foreach (var dummy in targetDummies)
        {
            dummy.GetComponent<TargetDummy>().ResetDummy();
        }

        isActivated = false;
        gameEnded = true;
    }
}
