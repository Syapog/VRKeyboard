using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffLeaderboard : MonoBehaviour
{
    [SerializeField] private LayerMask _keyboardMask;
    [SerializeField] private LayerMask _leaderboardMask;

    private bool _isLeaderboardSeen = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(_isLeaderboardSeen)
                Camera.main.cullingMask = _keyboardMask;
            else
                Camera.main.cullingMask = _leaderboardMask;

            _isLeaderboardSeen = !_isLeaderboardSeen;
        }
    }
}
