using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueDemo : MonoBehaviour
{
    public void goToDialogue1()
    {
        DialogueMotor.SetDialogue(Dialogues.greetings);
        SceneManager.LoadScene("Dialogue");
    }

    public void goToDialogue2()
    {
        DialogueMotor.SetDialogue(Dialogues.lupita);
        SceneManager.LoadScene("Dialogue");
    }
}
