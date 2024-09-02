using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsGenerator : MonoBehaviour
{
    [SerializeField] private Leaderboard _leaderboard;
    [SerializeField] private int _countOfRecords = 15;

    private void Start()
    {
        for (int i = 0; i < _countOfRecords; i++)
        {
            _leaderboard.AddRecord("Случайное имя" + i, Random.Range(1, 100));
        }
    }
}
