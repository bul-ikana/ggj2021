using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class IntroScene : MonoBehaviour
{
    private GameObject Julio;

    public void Start()
    {
        Julio = GameObject.Find("Julio");
        DontDestroyOnLoad(Julio);
        DialogueMotor.CurrentScene = SceneManager.GetActiveScene().buildIndex;

        // if (GameProgress.HasNot("VisitedPanthouse")) {
        //     // CasaButton.SetActive(false);
        //     // AbuelaButton.SetActive(false);
        //     // PanthouseButton.SetActive(true);
        // }

        // if (GameProgress.Has("VisitedPanthouse") && GameProgress.HasNot("PlayedGameOnce")) {
        //     CasaButton.SetActive(true);
        //     AbuelaButton.SetActive(false);
        //     GameProgress.Set("PlayedGameOnce", true);
        // }

        // if (GameProgress.Has("PlayedGameOnce")) {
        //     CasaButton.SetActive(true);
        //     PanthouseButton.SetActive(false);
        //     AbuelaButton.SetActive(false);
        // }

        // if (GameProgress.Has("VisitedCasa")) {
        //     CasaButton.SetActive(false);
        //     PanthouseButton.SetActive(false);
        //     AbuelaButton.SetActive(true);
        // }


    }

    public void PanthouseActions()
    {
        if (GameProgress.HasNot("CookedOnce")) {
            SceneManager.LoadScene("GamePlaceholder");
            GameProgress.Set("CookedOnce", true);
        }
    }

    public void CasaActions()
    {
        if (GameProgress.HasNot("GoneHomeStart")) {
            // Julio.SetActive(false);
            DialogueMotor.GoToDialogue(Dialogues.inicio);
            GameProgress.Set("GoneHomeStart", true);
        }
    }

    public void AbuelaActions()
    {
        Debug.Log("Abuela");
    }
}
