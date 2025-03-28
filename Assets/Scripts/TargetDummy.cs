using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator dummyAnimator;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Collider hitCollider;

    [Header("Settings")]
    [SerializeField] private float colliderDisableDelay = 0.5f;
    [SerializeField] private TargetDummy[] allDummies; // Список всех мишеней

    // Параметры аниматора
    private const string ACTIVATE_TRIGGER = "Activate";
    private const string DEATH_TRIGGER = "Death";

    private bool isDead = false;
    private bool isActive = false;

    private void Start()
    {
        if (hitCollider == null)
            hitCollider = GetComponent<Collider>();

        if (allDummies.Length == 0)
            allDummies = FindObjectsOfType<TargetDummy>(); // Автоматический поиск мишеней, если не задано вручную
    }


    public void ResetDummy()
    {
        isDead = false;
        isActive = false;

        // Сбрасываем все триггеры и включаем коллайдер
        dummyAnimator.ResetTrigger(ACTIVATE_TRIGGER);

        hitCollider.enabled = true;
    }

    public void ActivateDummy()
    {
        if (isDead) return;

        isActive = true;
        dummyAnimator.SetTrigger(ACTIVATE_TRIGGER);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isActive || isDead || !other.gameObject.CompareTag("Weapon")) return;

        Destroy(other.gameObject);
        StartDeath();
    }

    private void StartDeath()
    {
        isDead = true;
        dummyAnimator.SetTrigger(DEATH_TRIGGER);
        Invoke(nameof(DisableCollider), colliderDisableDelay);

        if (scoreManager != null)
            scoreManager.AddScore(10);

        // Поднимаем новую случайную мишень
        Invoke(nameof(ActivateRandomDummy), 1f); // Небольшая задержка перед поднятием новой мишени
    }

    private void DisableCollider()
    {
        hitCollider.enabled = false;
    }

    private void ActivateRandomDummy()
    {
        if (allDummies.Length == 0) return;

        TargetDummy randomDummy;
        do
        {
            randomDummy = allDummies[Random.Range(0, allDummies.Length)];
        }
        while (randomDummy == this || randomDummy.isDead); // Исключаем текущую и "мертвые" мишени

        randomDummy.ResetDummy();
        randomDummy.ActivateDummy();
    }
}