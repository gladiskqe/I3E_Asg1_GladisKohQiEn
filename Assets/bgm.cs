using UnityEngine;

public class bgm : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var audio = GetComponent<AudioSource>();
            audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
