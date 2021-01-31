using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueScene : MonoBehaviour
{
    private int index;
    private int? new_character;
    private int? prev_character;

    private Text dialogueText;
    private Character background;
    private Character character1;
    private Character character2;

    void Start()
    {
        index = 0;

        dialogueText = GameObject.Find("Text").GetComponent<Text>();

        background = GameObject.Find("Background").GetComponent<Character>();
        character1 = GameObject.Find("Character1").GetComponent<Character>();
        character2 = GameObject.Find("Character2").GetComponent<Character>();

        SetBackground();
        SetCharacters();
        RenderText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            index++;
            RenderText();
        }
    }

    private void SetBackground()
    {
        background.GetComponent<SpriteRenderer>().sprite = 
            Resources.Load<Sprite>(DialogueMotor.CurrentDialogue.BackgroundSprite);
    }

    private void SetCharacters()
    {
        character1.GetComponent<SpriteRenderer>().sprite = 
            Resources.Load<Sprite>(DialogueMotor.CurrentDialogue.Character1Sprite);

        character2.GetComponent<SpriteRenderer>().sprite = 
            Resources.Load<Sprite>(DialogueMotor.CurrentDialogue.Character2Sprite);
    }

    private void RenderText()
    {
        if (index < DialogueMotor.CurrentDialogue.Messages.Count) {
            new_character = DialogueMotor.CurrentDialogue.Messages[index].Character;
            if (prev_character == null || prev_character != new_character) {
                if (new_character == 0) {
                    character1.Highlight();
                    if (index != 0) character2.Deemphasize();
                } else {
                    character2.Highlight();
                    if (index != 0) character1.Deemphasize();
                }
            }

            dialogueText.text = DialogueMotor.CurrentDialogue.Messages[index].Text;   
            prev_character = new_character;
        } else {
            SceneManager.UnloadScene("Dialogue");
        }
    }
}
