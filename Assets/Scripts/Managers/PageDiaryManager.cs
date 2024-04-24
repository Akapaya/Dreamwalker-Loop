using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageDiaryManager : MonoBehaviour
{
    public PagesDiarys PagesDiarys = new PagesDiarys(Languages.Portuguese);
    private int _indexPage;

    [SerializeField] private PageViewManager PageViewManager;

    private GameObject _currentlyPage;
    [SerializeField] private List<GameObject> _pagesList = new List<GameObject>();

    #region Setters Methods
    public void SetNextDiaryPage()
    {
        string page = PagesDiarys.Messages[_indexPage];
        PageViewManager.SetTextDiary(page);
    }

    public void SetIndexPage(int value)
    {
        _indexPage = value;
    }
    #endregion

    #region Activate and Deactivate Pages
    public void ActivatePage()
    {
        _currentlyPage = _pagesList[Random.Range(0, _pagesList.Count)];
        _currentlyPage.SetActive(true);
    }

    public void DeactivatePage()
    {
        if (_currentlyPage != null)
        {
            _currentlyPage.SetActive(false);
        }
    }
    #endregion
}
