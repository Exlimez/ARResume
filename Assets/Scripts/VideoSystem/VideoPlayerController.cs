using System.Collections;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerController : MonoBehaviour {

    #region VARIABLES

    [SerializeField]
    VideoClip[] videoClips;
    [SerializeField]
    FloatVariable[] videoIntervals;


    public GameObject displayObject;

    VideoPlayer videoPlayer;

    bool showStop = false;

    #endregion //VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    #endregion //UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    public void ListenForProjectVideoWrapper()
    {
        StartCoroutine(ListenForProjectVideoCoroutine());   
    }

    public void CancelShow()
    {
        showStop = true;
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    IEnumerator ListenForProjectVideoCoroutine()
    {
        float clipLength;
        for (int i = 0; i < videoClips.Length; i++)
        {
            if (showStop)
            {
                showStop = false;
                break;
            }

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

    void PlayVideo(VideoClip clip)
    {
        videoPlayer.clip = clip;
        videoPlayer.Play();
    }

    #endregion // PRIVATE_METHODS

}
