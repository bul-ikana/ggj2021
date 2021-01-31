using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public void goToGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void deleteProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
