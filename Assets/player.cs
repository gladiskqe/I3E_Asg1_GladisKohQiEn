using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour

{   
    [SerializeField] private CongratsPopup CongratsPopup; // Reference to the CongratsPopup script
    [SerializeField] private CongratsPopup LockdoorPopup; // Reference to the LockdoorPopup script
    [SerializeField] private Exit Exit; // Reference to the Exit script
    [SerializeField] public int totalScore = 0;
    [SerializeField] public int totalCrystal = 0;

    [SerializeField] public TMP_Text CoinText;
    [SerializeField] public TMP_Text CrystalText;
    [SerializeField] public UIManager MyUIManager;

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
        if (other.CompareTag("Coin") || other.CompareTag("Crystal") || other.CompareTag("Exit"))
        {
            nearbyInteractable = other.gameObject;
            // Optional: show "Press E to collect" UI here
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coin") || other.CompareTag("Crystal") || other.CompareTag("Exit"))
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
    //Press E//
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
            CoinText.text = $"Coin: {totalScore}/15";

            if (MyUIManager != null)
                MyUIManager.SetScore(totalScore);

            collectible.Collect();
            nearbyInteractable = null;

                if (totalScore == 5) // 5 coins are needed to active popup//
                    {
                        CongratsPopup.ShowPopup(); // Show the congrats popup when the player collects all items
                    }
                return;

        }

        var crystal = nearbyInteractable.GetComponent<Crystal>();
        if (crystal != null)
        {
            totalCrystal += crystal.crystalValue;
            print($"Total Crystal: {totalCrystal}");
            CrystalText.text = $"Crystal: {totalCrystal}/1";

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
            door.Interact(totalCrystal); // Pass the total crystal count to the door's Interact method
            if (totalCrystal == 0) // Assuming 1 crystal is needed to open the door
            {
                LockdoorPopup.ShowPopup(); // Show the lockdoor popup when the player collects the required crystal
            }
        }

        var exit = nearbyInteractable.GetComponent<Exit>();
        if (exit != null)
        {
            print("Interacted with Exit");
            exit.Interact(totalScore); // Pass the total score to the exit's Interact method
        }
    }
}