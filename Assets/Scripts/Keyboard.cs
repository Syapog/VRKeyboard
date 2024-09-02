using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private TextMesh _textMesh;
    [SerializeField] private GameObject _keyPrefab;
    [SerializeField] private Leaderboard _leaderboard;

    private string _keyboardSymbols = "ЁЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
    private string _playerName = "";
    private int _keyCount = 0;

    private void Start()
    {
        GameObject newKey;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                newKey = Instantiate(_keyPrefab, gameObject.transform);
                newKey.transform.localPosition = new Vector3(j * 0.1f - 0.5f, -i * 0.1f + 0.1f, 0f);
                newKey.GetComponent<Key>().SetText(_keyboardSymbols[_keyCount].ToString(), this);
                _keyCount++;
            }
        }
        newKey = Instantiate(_keyPrefab, gameObject.transform);
        newKey.transform.localPosition = new Vector3(0f, -0.2f, 0f);
        newKey.transform.localScale = new Vector3(newKey.transform.localScale.x * 3f, newKey.transform.localScale.y, newKey.transform.localScale.z);
        newKey.GetComponent<Key>().SetText(('\u0020').ToString(), this);
        newKey = Instantiate(_keyPrefab, gameObject.transform);
        newKey.transform.localPosition = new Vector3(0.2f, -0.2f, 0f);
        newKey.GetComponent<Key>().SetText(('\u2190').ToString(), this);
        newKey = Instantiate(_keyPrefab, gameObject.transform);
        newKey.transform.localPosition = new Vector3(0.3f, -0.2f, 0f);
        newKey.GetComponent<Key>().SetText(('\u21B2').ToString(), this);
    }

    private void RefreshTextMesh()
    {
        _textMesh.text = _playerName;
    }

    public void AddSymbol(string symbol)
    {
        if (symbol == ('\u2190').ToString())
        {
            if(_playerName.Length != 0)
                _playerName = _playerName.Remove(_playerName.Length - 1);
        }
        else if(symbol == ('\u21B2').ToString())
        {
            _leaderboard.AddRecord(_playerName, Random.Range(1, 100));
            _playerName = "";
        }
        else if(_playerName.Length < 14)
        {
            _playerName += symbol;
        }
        RefreshTextMesh();
    }
}
