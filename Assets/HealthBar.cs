using UnityEngine;
using UnityEngine.UI; // Required for using UI elements like Image  33er5
public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Reference to the UI Slider component

    public void SetSlider(float amount)
    {
        healthSlider.value = amount; // Update the slider value to reflect current health
    }

    public void SetSliderMax(float amount)
    {
        healthSlider.maxValue = amount; // Set the maximum value of the slider to the player's max health
        SetSlider(amount); // Initialize the slider to full health
        
    }
}
