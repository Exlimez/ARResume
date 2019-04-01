using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CandidateManager : MonoBehaviour {

    [Header("Audio")]

    [SerializeField]
    AudioClip[] audioClips;
    AudioSource source;

    [SerializeField]
    FloatVariable[] showMoments; // show something by hand


    [Header("Managed events")]

    [SerializeField]
    GameEvent[] events;

    void Awake()
    {
        source = GetComponent<AudioSource>();   
    }

    public void Intro()
    {
        PlayAudio(audioClips[0]);
        StartCoroutine(ListenToEnd(audioClips[0].length));
    }

    public void PlayProjectsAudio()
    {
        PlayAudio(audioClips[1]);
        StartCoroutine(ListenToEnd(audioClips[1].length));
        StartCoroutine(ShowOnMoments(showMoments)); 
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

    void PlayAudio(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void CancelAudio()
    {
        source.Stop();
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

}
