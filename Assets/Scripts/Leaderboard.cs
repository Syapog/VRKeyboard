using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public enum ScrollDirection
{
    Up, Down
}

public struct Record
{
    public string Name;
    public int Score;

    public Record(string newName, int newScore)
    {
        Name = newName;
        Score = newScore;
    }
}

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private TextMesh _recordText;
    [SerializeField] private int _maxRecordsInListCount = 10;

    [SerializeField] private GameObject _upScrollButton;
    [SerializeField] private GameObject _downScrollButton;
    [SerializeField] private GameObject _scroller;

    private List<Record> _records;
    private int _actualListNumber = 1;
    private int _listsCount;

    private void Start()
    {
        _records = SaveManager.LoadFromFile();
        RefreshRecordsText();
        RecountScroller();
    }

    private void RefreshRecordsText()
    {
        _recordText.text = "";
        for (int i = _maxRecordsInListCount * _actualListNumber - _maxRecordsInListCount; i < _maxRecordsInListCount * _actualListNumber; i++)
        {
            if (i < _records.Count)
            {
                _recordText.text += (i + 1).ToString() + ". ";
                if (i + 1 <= 9)
                    _recordText.text += " ";
                _recordText.text += _records[i].Name + GetIndent(_records[i].Name.Length) + _records[i].Score.ToString() + "\n";
            }
            else
            {
                _recordText.text += (i + 1).ToString() + ". ";
                if (i + 1 <= 9)
                    _recordText.text += " ";
                _recordText.text += "ПУСТО" + GetIndent(5) + "\n";
            }
        }
    }

    private string GetIndent(int count)
    {
        string returnableString = "";

        for (int i = 0; i < 17 - count; i++)
        {
            returnableString += " ";
        }

        return returnableString;
    }

    private void RecountScroller()
    {
        GetListsCount();
        float scrollerArea = Vector3.Distance(_upScrollButton.transform.position, _downScrollButton.transform.position);
        float stepOfScroll = scrollerArea / (_listsCount + 1);
        _scroller.transform.localScale = new Vector3(_scroller.transform.localScale.x, stepOfScroll * 2f, _scroller.transform.localScale.z);
        _scroller.transform.localPosition = new Vector3(_scroller.transform.localPosition.x, _upScrollButton.transform.localPosition.y - stepOfScroll * _actualListNumber, _scroller.transform.localPosition.z);
    }

    private void GetListsCount()
    {
        if (_records.Count != 0)
        {
            _listsCount = _records.Count / _maxRecordsInListCount;
            if (_records.Count % _maxRecordsInListCount != 0)
                _listsCount++;
        }
        else
            _listsCount = 1;

    }

    public void AddRecord(string name, int score)
    {
        _records.Add(new Record(name, score));
        _records.Sort((a, b) => b.Score.CompareTo(a.Score));

        GetListsCount();

        RefreshRecordsText();
        RecountScroller();
        SaveManager.SaveToFile(_records);
    }

    public void ScrollList(ScrollDirection scroll)
    {
        if (scroll == ScrollDirection.Up)
        {
            if (_actualListNumber > 1)
                _actualListNumber--;
        }
        else
        {
            if (_actualListNumber < _listsCount)
                _actualListNumber++;
        }

        RefreshRecordsText();
        RecountScroller();
    }
}
