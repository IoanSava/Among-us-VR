using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SetName()
    {
        PlayerPrefs.SetString("name", inputField.text);
        Debug.LogFormat($"Nickname is {inputField.text}");
    }

    public void QuitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
