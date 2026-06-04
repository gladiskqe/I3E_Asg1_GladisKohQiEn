using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    int totalScore = 0;
    Collectible currentCoin;

    GameObject lastTrigger;

    bool isMenuShowing = false;

    public UIManager MyUIManager;

    void OnMenu()
    {
        MyUIManager.ShowMenu(isMenuShowing);
        isMenuShowing = !isMenuShowing;
    }
    void OnCollisionEnter(Collision collision)
        {   print(collision.gameObject.tag);

            if (collision.gameObject.tag=="Coin")
            {  
                totalScore++;
                print($"Coin score: {totalScore}");
                Destroy(collision.gameObject);
            }
        }
    void OnTriggerEnter(Collider other)
    {   

        print($"Triggered by {other.gameObject.name}");
        lastTrigger = other.gameObject;
        
    }
    void OnTriggerExit(Collider other)
    {
        print($"Stopped triggering by {other.gameObject.name}");
        lastTrigger = null;
    }
    /*void OnCollisionEnter(Collision collision)
    {   print(collision.gameObject.tag);

        if (collision.gameObject.tag=="Coin")
        {  
            totalScore++;
            print($"Coin score: {totalScore}");
            Destroy(collision.gameObject);
            print($"Collided with {lastTrigger.name}");
        }
    }*/

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
            print($"Score: {totalScore}");

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