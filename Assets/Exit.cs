using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject popupPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Interact(int totalScore)
    {
        if (totalScore == 15)
        {   
            print("Congratulations! You have collected all the coins and Exited!");
            ShowPopup();
        }
    }

    public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }
}
