using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeypadButton : MonoBehaviour
{
    [SerializeField] private KeypadTask keypad;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            keypad.keypadEvent.Invoke(gameObject.name);
        }
    }
}
