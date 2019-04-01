using UnityEngine;
using Vuforia;

public class CandidateTrackableEventHandler : DefaultTrackableEventHandler
{
    #region VARIABLES

    [SerializeField]
    GameEvent candidateFound;

    bool isFirstRecognition = true;
    
    #endregion // VARIABLES

    #region PROTECTED_METHODS

    protected override void OnTrackingFound()
    {
        if (isFirstRecognition)
        {
            candidateFound.Raise();
            isFirstRecognition = false;
        }

        base.OnTrackingFound();

    }

    #endregion // PROTECTED_METHODS
}
