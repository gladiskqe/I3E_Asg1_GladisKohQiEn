using UnityEngine;

public class DeathPopup : MonoBehaviour
    // Start is called once before the first execution of Update after the MonoBehaviour is created
{
    public GameObject popupPanel;

    public void ShowPopup()
    {
        popupPanel.SetActive(true);
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}