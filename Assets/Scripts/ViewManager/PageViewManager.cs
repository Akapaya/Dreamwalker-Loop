using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PageViewManager : MonoBehaviour
{
    [SerializeField] private GameObject _pageObjectPanel;
    [SerializeField] private TMP_Text _diaryText;

    #region Activate and Deactivate Methods
    public void ActivatePagePanel()
    {
        _pageObjectPanel.SetActive(true);
    }

    public void DeactivatePagePanel()
    {
        _pageObjectPanel.SetActive(false);
    }
    #endregion

    #region Setters Methods
    public void SetTextDiary(string text)
    {
        _diaryText.text = text;
    }
    #endregion
}