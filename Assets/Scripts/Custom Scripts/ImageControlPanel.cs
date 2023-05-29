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

    private void SetAllImageData()
    {
        SetImage();
        SetImageTitle();
        SetImageAuthor();
        SetImageDate();
    }
}
