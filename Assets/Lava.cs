using UnityEngine;

public class Lava : MonoBehaviour
{
    public float damage= 20; // Amount of damage to inflict on the player
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        print("Player touched lava!"); // Log when the player touches the lava for debugging
            other.GetComponent<PlayerStats>().TakeDamage(damage); // Inflict a large amount of damage to ensure the player dies
        }
    }
}
