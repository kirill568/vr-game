using UnityEngine;

public class DummyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] targetDummies;
    [SerializeField] private ScoreManager scoreManager; 

    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated || !other.CompareTag("Player"))
            return;

        isActivated = true;

        // Активируем систему подсчета
        scoreManager.ActivateSystem();

        // Активируем манекены
        foreach (var dummy in targetDummies)
        {
            dummy.GetComponent<TargetDummy>().ActivateDummy();
        }
    }
}