using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ImageChanger : MonoBehaviour {

    [SerializeField]
    string[] imageNames;
    [SerializeField]
    SizechangeableImage[] images;

    Dictionary<string, SizechangeableImage> imageDictionary;

    SpriteRenderer sRenderer;

    void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        try
        {
            for (int i = 0; i < imageNames.Length && i < images.Length; i++)
            {
                if (imageNames[i] == null || images[i] == null) throw new MissingReferenceException();
            }
        }
        catch (MissingReferenceException e)
        {
            Debug.LogException(e, this);
        }
    }

    public void ChangeImage(SizechangeableImage image)
    {
        sRenderer.sprite = image.sprite;
        sRenderer.size = image.size;
    }
}
