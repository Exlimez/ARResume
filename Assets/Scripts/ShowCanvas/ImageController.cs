using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageController : MonoBehaviour {

    #region VARIABLES

    [Header("ProjectsImages")]

    [SerializeField]
    SizechangeableImage[] projectsImages;
    [SerializeField]
    FloatVariable[] projectsIntervalTimes;
    [SerializeField]
    FloatVariable[] projectsDurationTimes;


    [Header("SkillsImages")]

    [SerializeField]
    SizechangeableImage[] skillsImages;
    [SerializeField]
    FloatVariable[] skillsIntervalTimes;
    [SerializeField]
    FloatVariable[] skillsDurationTimes;


    [Header("Display")]

    [SerializeField]
    GameObject displayObject;

    ImageChanger iChanger;


    bool showStop = false;

    #endregion // VARIABLES


    #region UNITY_MONOBEHAVIOUR_METHODS

    void Awake()
    {
        iChanger = displayObject.GetComponent<ImageChanger>();
    }

    #endregion //UNITY_MONOBEHAVIOUR_METHODS

    public void ListenForProjectsLogoWrapper()
    {
        StartCoroutine(ListenForProjectLogoCoroutine());
    }

    public void ListenForSkillsLogoWrapper()
    {
        StartCoroutine(ListenForSkillsLogoCoroutine());
    }

    public void CancelShow()
    {
        showStop = true; //not so simple (first module choosing)
    }

    IEnumerator ListenForProjectLogoCoroutine()
    {
        WaitForSeconds intervalWait;
        WaitForSeconds durationWait;

        for (int i = 0; i < projectsImages.Length; i++)
        {
            if (showStop)
            {
                showStop = false;
                break;
            }

            //yield return new WaitForSeconds(projectsIntervalTimes[i].Value); // try to inspect with profiler
            intervalWait = new WaitForSeconds(projectsIntervalTimes[i].Value);
            yield return intervalWait;

            displayObject.SetActive(true);
            iChanger.ChangeImage(projectsImages[i]);

            //yield return new WaitForSeconds(projectsDurationTimes[i].Value); // try to inspect with profiler
            durationWait = new WaitForSeconds(projectsDurationTimes[i].Value);
            yield return durationWait;

            displayObject.SetActive(false);
        }
    }


    IEnumerator ListenForSkillsLogoCoroutine()
    {
        WaitForSeconds intervalWait;
        WaitForSeconds durationWait;

        for (int i = 0; i < skillsImages.Length; i++)
        {
            if (showStop)
            {
                showStop = false;
                break;
            }

            //yield return new WaitForSeconds(skillsIntervalTimes[i].Value); // try to inspect with profiler
            intervalWait = new WaitForSeconds(skillsIntervalTimes[i].Value);
            Debug.Log("skillsIntervalTimes[i].Value =" + skillsIntervalTimes[i].Value);
            yield return intervalWait;

            displayObject.SetActive(true);
            iChanger.ChangeImage(skillsImages[i]);

            //yield return new WaitForSeconds(skillsDurationTimes[i].Value); // try to inspect with profiler
            durationWait = new WaitForSeconds(skillsDurationTimes[i].Value);
            yield return durationWait;

            displayObject.SetActive(false);
        }
    }

    
}
