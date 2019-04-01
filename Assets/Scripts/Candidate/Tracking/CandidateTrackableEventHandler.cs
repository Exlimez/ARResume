using UnityEngine;
using Vuforia;

public class CandidateTrackableEventHandler : DefaultTrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES

    bool isFirstRecognition = true;

    #endregion // PRIVATE_MEMBER_VARIABLES

    #region PUBLIC_MEMBER_VARIABLES

    public GameEvent candidateFound;

    #endregion // PUBLIC_MEMBER_VARIABLES

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
