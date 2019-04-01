using System.Collections;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerController : MonoBehaviour {
    
    [SerializeField]
    VideoClip[] videoClips;
    [SerializeField]
    FloatVariable[] videoIntervals;


    public GameObject displayObject;

    VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }


    public void PlayProjectVideoWrapper()
    {
        StartCoroutine(PlayProjectVideoCoroutine());   
    }

    IEnumerator PlayProjectVideoCoroutine()
    {
        float clipLength;
        for (int i = 0; i < videoClips.Length; i++)
        {
            yield return new WaitForSeconds(videoIntervals[i].Value); 

            displayObject.SetActive(true);
            PlayVideo(videoClips[i]);

            clipLength = (float) (videoClips[i].frameCount / videoClips[i].frameRate);
            StartCoroutine(ClosePlayerAfterDelay(clipLength));
        }
    }

    IEnumerator ClosePlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        displayObject.SetActive(false);

    }
    private void PlayVideo(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }

}
