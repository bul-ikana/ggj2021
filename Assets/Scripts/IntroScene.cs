using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class IntroScene : MonoBehaviour
{
    public GameObject PanthouseButton;
    public GameObject CasaButton;
    public GameObject AbuelaButton;

    public void Start()
    {
        DialogueMotor.CurrentScene = SceneManager.GetActiveScene().buildIndex;
        CasaButton = GameObject.Find("CasaButton");
        AbuelaButton = GameObject.Find("AbuelaButton");
        PanthouseButton = GameObject.Find("PanthouseButton");

        if (GameProgress.HasNot("VisitedPanthouse")) {
            CasaButton.SetActive(false);
            AbuelaButton.SetActive(false);
            PanthouseButton.SetActive(true);
        }

        if (GameProgress.Has("VisitedPanthouse") && GameProgress.HasNot("PlayedGameOnce")) {
            CasaButton.SetActive(true);
            AbuelaButton.SetActive(false);
            SceneManager.LoadScene("GamePlaceholder");
            GameProgress.Set("PlayedGameOnce", true);
        }

        if (GameProgress.Has("PlayedGameOnce")) {
            CasaButton.SetActive(true);
            PanthouseButton.SetActive(false);
            AbuelaButton.SetActive(false);
        }

        if (GameProgress.Has("VisitedCasa")) {
            CasaButton.SetActive(false);
            PanthouseButton.SetActive(false);
            AbuelaButton.SetActive(true);
        }


    }

    public void goToPanthouse()
    {
        GameProgress.Set("VisitedPanthouse", true);
        DialogueMotor.GoToDialogue(Dialogues.panthouse);
    }

    public void goToCasa()
    {
        GameProgress.Set("VisitedCasa", true);
        DialogueMotor.GoToDialogue(Dialogues.casa);
    }

    public void goToAbuela()
    {
        DialogueMotor.GoToDialogue(Dialogues.abuela);
    }
}
