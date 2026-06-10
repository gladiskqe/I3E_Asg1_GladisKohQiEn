using UnityEngine;

public class Collectible : MonoBehaviour
{
   
   public int score = 1;

   public void Collect()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            score += score;
            var audio = GetComponent<AudioSource>();
            audio.Play();

            var renderer = GetComponent<Renderer>();
            renderer.enabled = false;
            Destroy(gameObject, 1);
        }
    }
}
    