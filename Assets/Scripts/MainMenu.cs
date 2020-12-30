using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField inputField;
    private string nickname = "";

    public void SetName()
    {
        nickname = inputField.text;
        Debug.LogFormat($"Nickname is {nickname}");
    }

    public void QuitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
