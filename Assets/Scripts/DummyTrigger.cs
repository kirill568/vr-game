using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DummyTrigger : MonoBehaviour
{
    [Header("Game Setup")]
    [SerializeField] private GameObject[] targetDummies;
    [SerializeField] private ScoreManager scoreManager;

    [Header("UI Setup")]
    [SerializeField] private GameObject startPanel; // Основная панель
    [SerializeField] private TextMeshPro startText; // Текст на панели
    [SerializeField] private TextMeshPro timerText; // Таймер на панели
    [SerializeField] private BoxCollider startPanelCollider; // Коллайдер панели

    [Header("Game Settings")]
    [SerializeField] private float gameDuration = 60f;

    private bool isActivated = false;
    private float timeRemaining;

    private void Start()
    {
        timeRemaining = gameDuration;

        // Показываем стартовое время
        if (timerText != null)
        {
            timerText.text = $"Time: {Mathf.Ceil(timeRemaining)}";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated || !other.CompareTag("Player"))
            return;

        isActivated = true;

        // Включаем систему подсчета очков
        scoreManager.ActivateSystem();

        // Активируем мишени
        foreach (var dummy in targetDummies)
        {
            dummy.GetComponent<TargetDummy>().ActivateDummy();
        }

        // Скрываем стартовый текст, панель остаётся
        if (startText != null)
        {
            startText.gameObject.SetActive(false);
        }

        // Отключаем коллайдер панели, чтобы её можно было прострелить
        if (startPanelCollider != null)
        {
            startPanelCollider.enabled = false;
        }

        // Запускаем таймер
        StartCoroutine(GameTimer());
    }

    private IEnumerator GameTimer()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timerText != null)
            {
                timerText.text = $"Time: {Mathf.Ceil(timeRemaining)}";
            }

            yield return null;
        }

        EndGame();
    }

    private void EndGame()
    {
        // Возвращаем текст на панель
        if (startText != null)
        {
            startText.gameObject.SetActive(true);
            startText.text = "Time is out!";
        }

        // Включаем обратно коллайдер панели, если нужно
        if (startPanelCollider != null)
        {
            startPanelCollider.enabled = true;
        }

        // Останавливаем мишени
        foreach (var dummy in targetDummies)
        {
            dummy.GetComponent<TargetDummy>().ResetDummy();
        }

        isActivated = false;
    }
}
