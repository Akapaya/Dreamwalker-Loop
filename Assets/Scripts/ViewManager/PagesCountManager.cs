using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PagesCountManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _countText;
    private int _maxPagesCount;

    #region Setters Methods
    public void SetMaxPagesCount(int maxPagesCount)
    {
        _maxPagesCount = maxPagesCount;
    }
    #endregion

    #region Update View
    public void UpdatePagesCount(int pageCount)
    {
        _countText.text = pageCount.ToString() + "/" + _maxPagesCount;
    }
    #endregion
}