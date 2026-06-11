using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour


{
    int totalScore = 0;
    int totalCrystal = 0;  

    public TMP_Text CoinText;
    public TMP_Text CrystalText;
     public UIManager MyUIManager;

    GameObject nearbyInteractable;

    bool isMenuShowing = false;
    
    void OnMenu()
    {
        //MyUIManager.ShowMenu(isMenuShowing);
        //isMenuShowing = !isMenuShowing;
    }
     void OnInteract(InputValue value)
    {
        Interact();
    }
   
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E) && nearbyInteractable != null)
        // {
        //     if(nearbyInteractable.CompareTag("Coin"))
        //     {
        //         var collectible = nearbyInteractable.GetComponent<Collectible>();
        //         totalScore += collectible.score;
        //         print($"Coin: {totalScore}");
        //         CoinText.text = $"Coin: {totalScore}";

        //         if (MyUIManager != null)
        //             MyUIManager.SetScore(totalScore);

        //         collectible.Collect();
        //     }
        //     else if(nearbyInteractable.CompareTag("Crystal"))
        //     {
        //         var crystal = nearbyInteractable.GetComponent<Crystal>();
        //         totalCrystal += crystal.crystalValue;
        //         print($"Crystal: {totalCrystal}");
        //         CrystalText.text = $"Crystal: {totalCrystal}";

        //         if (MyUIManager != null)
        //             MyUIManager.SetScore(totalCrystal);

        //         crystal.Collect();
        //     }
        // }
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            nearbyInteractable = collision.gameObject;
            print($"Colliding with {collision.gameObject.name}");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Door"))
        {
            nearbyInteractable = null;
            print($"Stopped colliding with {collision.gameObject.name}");
        }
    }

    void Interact()
    {
        print("Interacted");
        if (nearbyInteractable == null)
            return;

        print($"Interacted with {nearbyInteractable.name}");
        
        var collectible = nearbyInteractable.GetComponent<Collectible>();
        if (collectible != null)
        {
            totalScore += collectible.score;
            print($"TotalScore: {totalScore}");
            CoinText.text = $"Coin: {totalScore}";

            if (MyUIManager != null)
                MyUIManager.SetScore(totalScore);

            collectible.Collect();
            nearbyInteractable = null;
            return;
        }

        var crystal = nearbyInteractable.GetComponent<Crystal>();
        if (crystal != null)
        {
            totalCrystal += crystal.crystalValue;
            print($"Total Crystal: {totalCrystal}");
            CrystalText.text = $"Crystal: {totalCrystal}";

            if (MyUIManager != null)
                MyUIManager.SetScore(totalCrystal);

            crystal.Collect();
            nearbyInteractable = null;
            return;
        }

        var door = nearbyInteractable.GetComponent<Door>();
        if (door != null)
        {
            print("Interacted with door");
            door.Interact();
        }
    }
}