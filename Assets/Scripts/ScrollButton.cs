using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollButton : Button
{
    [SerializeField] private ScrollDirection _scrollDirection;
    [SerializeField] private Leaderboard _leaderboard;

    public override void OnClick()
    {
        _leaderboard.ScrollList(_scrollDirection);
    }
}
