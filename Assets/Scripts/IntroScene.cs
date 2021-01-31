using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class IntroScene : MonoBehaviour
{
    private GameObject Sobre;

    public void Start()
    {
        Sobre = GameObject.Find("Sobre");
        Sobre.SetActive(false);
        DialogueMotor.CurrentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void PanthouseActions()
    {
        if (GameProgress.HasNot("CookedOnce")) {
            SceneManager.LoadScene("CookingScene", LoadSceneMode.Additive);
            GameProgress.Set("CookedOnce", true);
            Sobre.SetActive(true);
        }
    }

    public void CasaActions()
    {
        if (GameProgress.HasNot("GoneHomeStart")) {
            // Julio.SetActive(false);
            DialogueMotor.GoToDialogue(Dialogues.inicio);
            GameProgress.Set("GoneHomeStart", true);
        }

        if (GameProgress.Has("CookedOnce")) {
            DialogueMotor.GoToDialogue(Dialogues.casa);
            GameProgress.Set("ReadLetter", true);
            Sobre.SetActive(false);
        }
    }
}
