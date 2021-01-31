using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class IntroScene : MonoBehaviour
{
    private GameObject Sobre;
    private GameObject Flecha;

    public void Start()
    {
        Sobre = GameObject.Find("Sobre");
        Flecha = GameObject.Find("Flecha");
        Sobre.SetActive(false);
        Flecha.SetActive(false);
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
            DialogueMotor.GoToDialogue(Dialogues.inicio);
            GameProgress.Set("GoneHomeStart", true);
        }

        if (GameProgress.Has("CookedOnce") && GameProgress.HasNot("ReadLetter")) {
            DialogueMotor.GoToDialogue(Dialogues.casa);
            GameProgress.Set("ReadLetter", true);
            Sobre.SetActive(false);
            Flecha.SetActive(true);
        }
    }

    public void LeaveActions ()
    {
        if (GameProgress.Has("ReadLetter")) {
            SceneManager.LoadSceneAsync("TownMap");
        }
    }
}
