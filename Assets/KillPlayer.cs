using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject deathPopup; // Drag your popup UI here in Inspector
    [SerializeField] private float delayBeforeReload = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deathPopup.SetActive(true); // Show the popup
            StartCoroutine(ReloadAfterDelay());
        }
    }

    private IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeReload); // Wait, then reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}