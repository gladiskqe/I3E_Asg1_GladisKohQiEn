using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    int totalScore = 0;

    public TMP_Text ScoreText;
    Collectible Coin;

    GameObject lastTrigger;

    bool isMenuShowing = false;

    public UIManager MyUIManager;

    void OnMenu()
    {
        MyUIManager.ShowMenu(isMenuShowing);
        isMenuShowing = !isMenuShowing;
    }
    /*void OnCollisionEnter(Collision collision)
        {   print(collision.gameObject.tag);

            if (collision.gameObject.tag=="Coin")
            {  
                totalScore++;
                ScoreText.text = $"Score: {totalScore}";
                Destroy(collision.gameObject);
            }
        }*/
   
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

        var door = lastTrigger.GetComponent<Door>();
        if (door != null)
        {
            print("Interacted with door");
            door.Interact();
        }
    }
}