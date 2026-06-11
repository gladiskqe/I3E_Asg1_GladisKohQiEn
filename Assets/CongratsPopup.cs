using UnityEngine;
using System.Collections; 

public class CongratsPopup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject popupPanel;

    public void ShowPopup()
    {
        popupPanel.SetActive(true);

        StartCoroutine(CloseAfterDelay(2f));
    }

    IEnumerator CloseAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        popupPanel.SetActive(false);
    }
}