using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

public class menu : MonoBehaviour
{
    public Transform entryParent;

    public SavePlayerName savePlayer;
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Play()
    {
        savePlayer.SaveName();
        if (savePlayer.playerNameInput.text != null)
            SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
