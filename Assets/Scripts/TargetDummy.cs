using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator dummyAnimator;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Collider hitCollider;

    [Header("Settings")]
    [SerializeField] private float colliderDisableDelay = 0.5f;
    [SerializeField] private TargetDummy[] allDummies;

    [Header("Audio")]
    [SerializeField] private AudioSource hitSoundSource; // Звук попадания

    private const string ACTIVATE_TRIGGER = "Activate";
    private const string DEATH_TRIGGER = "Death";

    private bool isDead = false;
    private bool isActive = false;

    private void Start()
    {
        if (hitCollider == null)
            hitCollider = GetComponent<Collider>();

        if (allDummies.Length == 0)
            allDummies = FindObjectsOfType<TargetDummy>();

        // Отключаем коллайдер в самом начале
        hitCollider.enabled = false;
    }

    public void ResetDummy()
    {
        isDead = false;
        isActive = false;

        dummyAnimator.ResetTrigger(ACTIVATE_TRIGGER);
        dummyAnimator.ResetTrigger(DEATH_TRIGGER);

        hitCollider.enabled = false; // Оставляем выключенным до активации

        dummyAnimator.Play("Idle", 0, 0);
    }

    public void ActivateDummy()
    {
        if (isDead) return;

        isActive = true;
        hitCollider.enabled = true; // Включаем коллайдер перед активацией
        dummyAnimator.SetTrigger(ACTIVATE_TRIGGER);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isActive || isDead || !other.gameObject.CompareTag("Weapon")) return;

        // Воспроизводим звук попадания сразу
        if (hitSoundSource != null)
        {
            hitSoundSource.Play();
        }

        Destroy(other.gameObject);
        StartDeath();
    }

    private void StartDeath()
    {
        isDead = true;
        dummyAnimator.SetTrigger(DEATH_TRIGGER);

        // Отключаем коллайдер сразу после попадания
        hitCollider.enabled = false;

        if (scoreManager != null)
            scoreManager.AddScore(10);

        Invoke(nameof(ActivateRandomDummy), 1f);
    }

    private void ActivateRandomDummy()
    {
        if (allDummies.Length == 0) return;

        if (System.Array.TrueForAll(allDummies, d => d.isDead))
        {
            foreach (var dummy in allDummies)
            {
                dummy.ResetDummy();
            }
        }

        TargetDummy randomDummy;
        do
        {
            randomDummy = allDummies[Random.Range(0, allDummies.Length)];
        }
        while (randomDummy == this || randomDummy.isDead);

        randomDummy.ActivateDummy();
    }
}
