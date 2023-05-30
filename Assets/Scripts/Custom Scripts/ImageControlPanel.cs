using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageControlPanel : MonoBehaviour
{
    [SerializeField]
    private InfoPanel infoPanel;

    [SerializeField]
    private Image imageField;

    [SerializeField]
    private TextMeshProUGUI titleField;

    [SerializeField]
    private TextMeshProUGUI authorField;

    [SerializeField]
    private TextMeshProUGUI dateField;

    private int currentImage;

    // [SerializeField]
    // private AspectRatioFitter aspectRatioFitter;

    private List<ImageData> listOfImageScriptables;

    void Start()
    {

        listOfImageScriptables = infoPanel.GetImages();

        if (listOfImageScriptables.Count > 0)
        {
            currentImage = 0;
            SetAllImageData();
        }

    }

    public void NextImage()
    {
        currentImage++;
        if (currentImage >= listOfImageScriptables.Count)
        {
            currentImage = 0;
        }
        SetAllImageData();
    }

    public void PreviousImage()
    {
        currentImage--;
        if (currentImage < 0)
        {
            currentImage = listOfImageScriptables.Count - 1;
        }
        SetAllImageData();
    }

    private void SetImage()
    {
        imageField.sprite = listOfImageScriptables[currentImage].GetImage();
        UpdateSpriteSize();
    }

    private void SetImageTitle()
    {
        titleField.text = listOfImageScriptables[currentImage].GetImageTitle();
    }

    private void SetImageAuthor()
    {
        authorField.text = listOfImageScriptables[currentImage].GetImageAuthor();
    }

    private void SetImageDate()
    {
        dateField.text = listOfImageScriptables[currentImage].GetImageDate();
    }

    private void UpdateSpriteSize()
    {
        if (imageField.sprite != null)
        {
            // Update the AspectRatioFitter's aspect ratio to match the sprite's width/height
            Sprite image = listOfImageScriptables[currentImage].GetImage();
            float newRatio = image.rect.width / image.rect.height;

            Debug.Log("Image.name: " + image.name);
            Debug.Log("Image.rect.width: " + image.rect.width);
            Debug.Log("Image.rect.height: " + image.rect.height);

            //aspectRatioFitter.aspectRatio = newRatio;

        }
        else
        {
            Debug.Log("UpdateSpriteSize() didn't find a sprite!");
        }
    }

    private void SetAllImageData()
    {
        SetImage();
        SetImageTitle();
        SetImageAuthor();
        SetImageDate();
    }

}
