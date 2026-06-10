using UnityEngine;
using UnityEngine.SceneManagement; // Required for reloading the level

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    public HealthBar healthBar; // Reference to the HealthBar script

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health at the start
        healthBar.SetSliderMax(maxHealth); // Set the health bar's maximum value to the player's max health
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount; // Reduce current health by the damage amount
        healthBar.SetSlider(currentHealth); // Update the health bar to reflect the new health value

        if (currentHealth <= 0)
        {
            Die(); // Call the Die method if health drops to zero or below
    
        }
    }

    void Die()
    {
        /*Reload the current active scene to reset everything*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}