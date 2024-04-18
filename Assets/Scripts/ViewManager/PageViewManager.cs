using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageViewManager : MonoBehaviour
{
    [SerializeField] private GameObject pageObjectPanel;
    [SerializeField] private TMP_Text diaryText;

    public void ActivatePagePanel()
    {
        pageObjectPanel.SetActive(true);
    }

    public void DeactivatePagePanel()
    {
        pageObjectPanel.SetActive(false);
    }

    public void SetTextDiary(string text)
    {
        diaryText.text = text;
    }
}