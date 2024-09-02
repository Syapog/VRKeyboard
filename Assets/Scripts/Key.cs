using System.Collections;
using System.Collections.Generic;
using UnityEngine.TextCore;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Key : Button
{
    private Keyboard _keyboard;

    public void SetText(string text, Keyboard keyboard)
    {
        _keyText.text = text;
        _keyboard = keyboard;
    }

    public override void OnClick()
    {
        _keyboard.AddSymbol(_keyText.text);
    }
}
