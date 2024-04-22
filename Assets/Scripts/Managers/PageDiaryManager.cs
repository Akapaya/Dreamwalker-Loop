using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageDiaryManager : MonoBehaviour
{
    public PagesDiarys PagesDiarys = new PagesDiarys(Languages.Portuguese);
    private int indexPage;

    [SerializeField] private PageViewManager PageViewManager;

    private GameObject currentlyPage;
    [SerializeField] private List<GameObject> pagesList = new List<GameObject>();

    public void SetNextDiaryPage()
    {
        string page = PagesDiarys.Messages[indexPage];
        PageViewManager.SetTextDiary(page);
    }

    public void SetIndexPage(int value)
    {
        indexPage = value;
    }

    public void ActivatePage()
    {
        currentlyPage = pagesList[Random.Range(0, pagesList.Count)];
        currentlyPage.SetActive(true);
    }

    public void DeactivatePage()
    {
        if (currentlyPage != null)
        {
            currentlyPage.SetActive(false);
        }
    }
}
