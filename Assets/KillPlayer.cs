using UnityEngine;
using UnityEngine.SceneManagement; // Required for reloading the level
public class KillPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Die();
        }
    }
    

    void Die()
    {
        /*Reload the current active scene to reset everything*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

