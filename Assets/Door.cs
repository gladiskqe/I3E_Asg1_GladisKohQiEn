using UnityEngine;

public class Door : MonoBehaviour
{
    public Vector3 rotateAmount = new Vector3(0, 80f, 0); // Amount to rotate the door when opened
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isOpen = false; // Track whether the door is open or closed   
    
    public void Interact()
    {   if (Input.GetKeyDown(KeyCode.E))
        {   
            if (!isOpen) transform.Rotate(rotateAmount); // Rotate the door to open it
            else transform.Rotate(rotateAmount * -1); // Rotate the door back to close it
            isOpen = !isOpen; // Mark the door as open
        }
    }
    
}
