using UnityEngine;

public class Crystal : MonoBehaviour
{

   public int crystalValue = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void Collect()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
           print(crystalValue);
            var audio = GetComponent<AudioSource>();
            audio.Play();

            var renderer = GetComponent<Renderer>();
            renderer.enabled = false;
            Destroy(gameObject, 1);
        }
    }
}
