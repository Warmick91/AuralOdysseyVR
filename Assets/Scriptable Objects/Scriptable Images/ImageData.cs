using UnityEngine;

[CreateAssetMenu(fileName = "PeriodImage", menuName = "Scriptable Objects/Images/PeriodImage")]
public class ImageData : ScriptableObject
{
    [TextArea(3, 3)]
    [SerializeField]
    protected string imageTitle;

    [SerializeField]
    protected Sprite image;

    [TextArea(1, 2)]
    [SerializeField]
    protected string imageAuthor;

    [SerializeField]
    protected string imageDate;

    public Sprite GetImage()
    {
        return image;
    }

    public string GetImageTitle()
    {
        return imageTitle;
    }

    public string GetImageAuthor()
    {
        return imageAuthor;
    }

    public string GetImageDate()
    {
        return imageDate;
    }
}
