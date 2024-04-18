using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageDiaryManager : MonoBehaviour
{
    public PagesDiarys PagesDiarys = new PagesDiarys(Languages.Portuguese);
    private int indexPage;

    [SerializeField] private PageViewManager PageViewManager;

    public void SetNextDiaryPage()
    {
        string page = PagesDiarys.Messages[indexPage];
        PageViewManager.SetTextDiary(page);
    }

    public void SetIndexPage(int value)
    {
        indexPage = value;
    }
}
