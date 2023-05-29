using UnityEngine;

public abstract class ImageData : ScriptableObject
{
    [SerializeField]
    protected string imageTitle;

    [SerializeField]
    protected Sprite image;

    [TextArea(3, 3)]
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
