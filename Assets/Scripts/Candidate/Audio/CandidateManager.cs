using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CandidateManager : MonoBehaviour {

    #region VARIABLES

    [Header("Audio")]

    [SerializeField]
    AudioClip[] audioClips;

    AudioSource source;


    [Header("Video")]

    [SerializeField]
    FloatVariable[] videoMoments; // show video with hand (animation only)


    [Header("Managed events")]

    [SerializeField]
    GameEvent[] events;

    #endregion // VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    void Awake()
    {
        source = GetComponent<AudioSource>();   
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    public void Intro()
    {
        PlayAudio(audioClips[0]);
        StartCoroutine(ListenToEnd(audioClips[0].length));
    }

    public void PlayProjectsAudio()
    {
        PlayAudio(audioClips[1]);
        StartCoroutine(ListenToEnd(audioClips[1].length));
        StartCoroutine(ShowOnMoments(videoMoments)); 
    }

    public void PlaySkillsAudio()
    {
        PlayAudio(audioClips[2]);
        StartCoroutine(ListenToEnd(audioClips[2].length));
    }

    public void PlayAboutMeAudio()
    {
        PlayAudio(audioClips[3]);
        StartCoroutine(ListenToEnd(audioClips[3].length));
    }

    public void CancelAudio()
    {
        source.Stop();
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS
    
    void PlayAudio(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    IEnumerator ListenToEnd(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        events[0].Raise(); //module Choosing
    }

    IEnumerator ShowOnMoments(FloatVariable[] showMoments)
    {
        foreach (var time in showMoments)
        {
            yield return new WaitForSeconds(time.Value);
            events[1].Raise(); // show with hand
        }
    }

    #endregion // PRIVATE_METHODS

}
