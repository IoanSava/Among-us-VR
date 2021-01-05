using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class KeypadTask : MonoBehaviour
{
    public class StringEvent : UnityEvent<String> { }
    public StringEvent keypadEvent = new StringEvent();

    [SerializeField] private Text code;
    [SerializeField] private Text hint;

    // Start is called before the first frame update
    void Start()
    {
        code.text = "";
        keypadEvent.AddListener(KeypadButtonPressed);
        RandomizeHint();
    }

    private static String RandomDigit()
    {
        return Random.Range(0, 9).ToString();
    }

    private void KeypadButtonPressed(string buttonName)
    {
        switch (buttonName)
        {
            case "OK":
                if (IsDone())
                {
                    Debug.Log("Yaaay the task is done");
                }
                break;
            case "X":
                code.text = "";
                break;
            default:
                if (code.text.Length < 4)
                    code.text += buttonName;
                break;
        }
    }

    private bool IsDone()
    {
        return code.text.Length == 4 && hint.text.Equals(code.text);
    }

    private void RandomizeHint()
    {
        hint.text = "";
        for (int i = 0; i < 4; i++)
        {
            hint.text += RandomDigit();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
