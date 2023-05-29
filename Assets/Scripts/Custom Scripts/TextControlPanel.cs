using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TextControlPanel : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI periodInfoText;

    [SerializeField]
    private Button previousTextButton;

    [SerializeField]
    private Button nextTextButton;

    [SerializeField]
    private TextMeshProUGUI pageCounter;

    void OnEnable()
    {
        if (periodInfoText != null)
        {
            StartCoroutine(InitializePageCounter());
        }
        else
        {
            Debug.Log("periodInfoText is not assigned in TextControlPanel");
        }
    }

    private IEnumerator InitializePageCounter()
    {
        /*  Wait until the next frame. Without it the number of pages is set to an initial 0 due to the way TMProUGUI calculates the page count
            until AFTER the first frame is rendered.*/
        yield return null;

        // Reset the shown page and the page counter
        periodInfoText.pageToDisplay = 1;
        ShowCurrentPage();
    }

    public void NextPage()
    {
        if (periodInfoText != null)
        {
            periodInfoText.pageToDisplay++;
            if (periodInfoText.pageToDisplay > periodInfoText.textInfo.pageCount)
            {
                periodInfoText.pageToDisplay = 1;
            }
            ShowCurrentPage();
        }

    }

    public void PreviousPage()
    {
        if (periodInfoText != null)
        {
            periodInfoText.pageToDisplay--;
            if (periodInfoText.pageToDisplay < 1)
            {
                periodInfoText.pageToDisplay = periodInfoText.textInfo.pageCount;
            }
            ShowCurrentPage();
        }
    }

    private void ShowCurrentPage()
    {
        if (periodInfoText != null && pageCounter != null)
        {
            pageCounter.text = $"Page {periodInfoText.pageToDisplay}/{periodInfoText.textInfo.pageCount}";
        }
        else
        {
            if (periodInfoText == null)
            {
                Debug.Log("periodInfoText is not assigned in TextControlPanel");
            }

            if (pageCounter == null)
            {
                Debug.Log("pageCounter is not assigned in TextControlPanel");
            }
        }
    }
}
