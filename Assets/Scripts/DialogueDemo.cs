using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueDemo : MonoBehaviour
{
    public void goToDialogue1()
    {
        DialogueSettings.text = new string[] {
            "Hey dude!",
            "Wassap?",
            "Not much dawg"
        };

        SceneManager.LoadScene("Dialogue");
    }

    public void goToDialogue2()
    {
        DialogueSettings.text = new string[] {
            "Que le pasa a la niña?",
            "No se",
            "Que es lo que quiere?",
            "Bailar!"
        };

        SceneManager.LoadScene("Dialogue");
    }
}
