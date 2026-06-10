using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    int totalScore = 0;
    int totalCrystal = 0;  

    public TMP_Text ScoreText;
     public UIManager MyUIManager;

    GameObject lastTrigger;

    bool isMenuShowing = false;
    
    void OnMenu()
    {
        MyUIManager.ShowMenu(isMenuShowing);
        isMenuShowing = !isMenuShowing;
    }
     void OnInteract(InputValue value)
    {
        Interact();
    }
   
    /*E to collect*/
    private GameObject nearbyInteractable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearbyInteractable != null)
        {
            nearbyInteractable.GetComponent<Collectible>().Collect();
            nearbyInteractable.GetComponent<Crystal>().Collect();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin") || other.CompareTag("Crystal"))
        {
            nearbyInteractable = other.gameObject;
            // Optional: show "Press E to collect" UI here
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coin") || other.CompareTag("Crystal"))
        {
            nearbyInteractable = null;
        }
    }

        void OnCollisionExit(Collision collision)
    {
        lastTrigger = null;
        print($"Stopped colliding with {collision.gameObject.name}");

    }

    void Interact()
    {
        if (lastTrigger == null)
            return;

        print($"Interacted with {lastTrigger.name}");
        
        var collectible = lastTrigger.GetComponent<Collectible>();
        if (collectible != null)
        {
            totalScore += collectible.score;
            print($"TotalScore: {totalScore}");
            ScoreText.text = $"Score: {totalScore}";

            if (MyUIManager != null)
                MyUIManager.SetScore(totalScore);

            collectible.Collect();
            lastTrigger = null;
            return;
        }

        var crystal = lastTrigger.GetComponent<Crystal>();
        if (crystal != null)
        {
            totalCrystal += crystal.crystalValue;
            print($"Total Crystal: {totalCrystal}");
            ScoreText.text = $"Crystal: {totalCrystal}";

            if (MyUIManager != null)
                MyUIManager.SetScore(totalCrystal);

            crystal.Collect();
            lastTrigger = null;
            return;
        }

        var door = lastTrigger.GetComponent<Door>();
        if (door != null)
        {
            print("Interacted with door");
            door.Interact();
        }
    }
}