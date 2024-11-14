using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;

public class PlayVideoOnQ : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage videoScreen;
    public Image activeImage;       // Reference to the image that needs to be active to allow video playback

    private bool isPlaying = false;

    void Start()
    {
        videoScreen.enabled = false;  // Hide the video screen initially
    }

    void Update()
    {
        // Check if 'Q' is pressed, the video isn't playing, and activeImage is enabled
        if (Input.GetKeyDown(KeyCode.Q) && !isPlaying && activeImage != null && activeImage.enabled)
        {
            videoScreen.enabled = true;    // Show the video screen
            videoPlayer.Play();            // Start playing the video
            isPlaying = true;

            // Start coroutine to stop the video after 7 seconds
            StartCoroutine(StopVideoAfterDelay(7f));
        }

        // If the video has stopped playing, hide the screen and reset
        if (!videoPlayer.isPlaying && isPlaying)
        {
            videoScreen.enabled = false;  // Hide the video screen
            isPlaying = false;            // Reset play status
        }
    }

    // Coroutine to stop the video after a specified delay
    private IEnumerator StopVideoAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (isPlaying)
        {
            videoPlayer.Stop();             // Stop the video after the delay
            videoScreen.enabled = false;    // Hide the video screen
            isPlaying = false;              // Reset the play status
        }
    }
}
