using UnityEngine;
using System.Collections; 

public class CongratsPopup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject popupPanel;

    public void ShowPopup()
    {
        popupPanel.SetActive(true);
        //pops up for 2 seconds//
        StartCoroutine(CloseAfterDelay(2f));
    }
    //closes the popup after a delay//
    IEnumerator CloseAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        popupPanel.SetActive(false);
    }
}