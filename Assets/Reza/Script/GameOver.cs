using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections; // Optional if you want to load a new scene

public class GameOver : MonoBehaviour
{
    public float waitTime = 7f; // Time to wait before the music starts
    public AudioSource music; // Assign your audio source here
    public Image fadeImage; // UI Image to handle the screen fade
    public float fadeSpeed = 5f; // Speed of the fade effect

    private bool hasMusicStarted = false;
    private bool isFading = false;

    private void Start()
    {
        if (fadeImage != null)
        {
            // Set the initial fade image color to transparent
            fadeImage.color = new Color(1, 1, 1, 0);
        }

        // Start the waiting process
        StartCoroutine(WaitAndStartMusic());
    }

    private IEnumerator WaitAndStartMusic()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(waitTime);

        // Start the music
        if (music != null)
        {
            music.Play();
        }

        // Begin the fade to white
        isFading = true;
    }

    private void Update()
    {
        // Handle fading effect
        if (isFading && fadeImage != null)
        {
            // Gradually increase the alpha value of the fade image
            Color currentColor = fadeImage.color;
            currentColor.a += fadeSpeed * Time.deltaTime;
            fadeImage.color = currentColor;

            // Stop fading once the screen is fully white
            if (currentColor.a >= 1)
            {
                isFading = false;

                // Optional: Transition to another scene or stop everything
                
            }
           
        }

         if(!music.isPlaying && music.time > 0f){
                SceneManager.LoadScene("GameOverScene");
        }
    }

    
}
