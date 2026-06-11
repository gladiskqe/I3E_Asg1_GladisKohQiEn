using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 rotateAmount = new Vector3(0, 80f, 0); // Amount to rotate the door when opened
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isOpen = false; // Track whether the door is open or closed  
    [SerializeField] private CongratsPopup LockdoorPopup; // Reference to the LockdoorPopup script
    
    public void Interact(int crystalCount)
    {  
            if (crystalCount >= 1) // Check if the player has collected the required crystal
            {
                if (!isOpen) transform.parent.Rotate(rotateAmount); // Rotate the door to open it
                else transform.parent.Rotate(rotateAmount * -1); // Rotate the door back to close it
                isOpen = !isOpen; // Mark the door as open
            }
            else if (crystalCount < 1) // Check if the player has not collected the required crystal
            {
                print("You need to collect the crystal to open the door!"); // Log a message if the player
                //LockdoorPopup.ShowPopup(); // Show the lockdoor popup when the player collects the required crystal tries to open the door without collecting the crystal
            }
        }
    
}
