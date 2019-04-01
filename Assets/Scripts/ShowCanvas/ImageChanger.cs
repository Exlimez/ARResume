using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ImageChanger : MonoBehaviour {

    #region VARIABLES

    SpriteRenderer sRenderer;

    #endregion // VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    #endregion //UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    public void ChangeImage(SizechangeableImage image)
    {
        sRenderer.sprite = image.sprite;
        sRenderer.size = image.size;
    }

    #endregion // PUBLIC_METHODS
}
