using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayVideoOnQ : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage videoScreen;
    private bool isPlaying = false;

    void Start()
    {
        videoScreen.enabled = false;  // Verberg het scherm bij het starten
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isPlaying)
        {
            videoScreen.enabled = true;  // Toon het scherm
            videoPlayer.Play();  // Start de video
            isPlaying = true;
        }

        // Als de video is afgelopen, verberg het scherm en reset
        if (!videoPlayer.isPlaying && isPlaying)
        {
            videoScreen.enabled = false;  // Verberg het scherm
            isPlaying = false;  // Zet de status terug naar niet spelen
        }
    }
}