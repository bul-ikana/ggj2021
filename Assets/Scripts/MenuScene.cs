using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public void goToGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Intro");
    }

    public void goToAbout()
    {
        SceneManager.LoadScene("AboutScene");
    }
}
