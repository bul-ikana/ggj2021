using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueScene : MonoBehaviour
{
    private int index;

	private Text dialogueText;
    private Character character1;
    private Character character2;

    void Start()
    {
        index = 0;

        dialogueText = GameObject.Find("Text").GetComponent<Text>();

        character1 = GameObject.Find("Character1").GetComponent<Character>();
        character2 = GameObject.Find("Character2").GetComponent<Character>();

        RenderText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            index++;
            RenderText();
        }
    }

    private void RenderText()
    {
        if (index < DialogueMotor.CurrentDialogue.Messages.Count) {

            if (DialogueMotor.CurrentDialogue.Messages[index].Character == 0) {
                character1.Highlight();
                if (index != 0) character2.Deemphasize();
            } else {
                character2.Highlight();
                if (index != 0) character1.Deemphasize();
            }

            dialogueText.text = DialogueMotor.CurrentDialogue.Messages[index].Text;   
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
