using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator dummyAnimator;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Collider hitCollider;

    [Header("Settings")]
    [SerializeField] private float colliderDisableDelay = 0.5f;
    [SerializeField] private bool startActive = false;

    private bool isDead = false;
    private bool isSystemActive = false; // Флаг активности системы

    private void Start()
    {
        if (hitCollider == null)
            hitCollider = GetComponent<Collider>();

        isSystemActive = startActive; // Для ручной активации в редакторе
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isDead || !other.gameObject.CompareTag("Weapon")) return;

        Destroy(other.gameObject);

        StartDeath();
    }

    private void StartDeath()
    {
        isDead = true;

        dummyAnimator.SetTrigger("Death");

        Invoke(nameof(DisableCollider), colliderDisableDelay);

        if (scoreManager != null)
            scoreManager.AddScore(10);
    }

    private void DisableCollider()
    {
        if (hitCollider != null)
            hitCollider.enabled = false;
    }

    public void ResetDummy()
    {
        isDead = false;
        dummyAnimator.SetTrigger("Reset");
        hitCollider.enabled = true;
    }
    public void ActivateDummy()
    {
        dummyAnimator.SetTrigger("Activate");
    }
}



