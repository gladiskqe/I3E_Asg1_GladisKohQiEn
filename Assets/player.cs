using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    int totalScore = 0;

    GameObject lastTrigger;

    bool isMenuShowing = false;

    public UIManager MyUIManager;

    void OnMenu()
    {
        MyUIManager.ShowMenu(isMenuShowing);
        isMenuShowing = !isMenuShowing;
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
    void OnCollisionEnter(Collision collision)
    {
       lastTrigger = collision.gameObject;
       print($"Collided with {lastTrigger.name}");
    }

    void OnCollisionExit(Collision collision)
    {
        lastTrigger = null;
        print($"Stopped colliding with {collision.gameObject.name}");

    }

    void OnInteract(InputValue value)
    {
        if (lastTrigger != null)
        {
            print($"Interacted with {lastTrigger.name}");
            var collectable = lastTrigger.GetComponent<Collectible>();
            if (collectable != null)
            {
                totalScore += collectable.score;
                print($"Score: {totalScore}");
                collectable.Collect();
            }

            var door = lastTrigger.GetComponent<Door>();
            if (door != null)
            {
                print("Interacted with door");
                door.Interact();
            }
        }
    }
}