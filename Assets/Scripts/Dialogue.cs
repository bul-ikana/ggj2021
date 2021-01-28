using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    private int index;

	private Text dialogueText;

    void Start()
    {
        index = 0;
        dialogueText = GameObject.Find("Text").GetComponent<Text>();

        RenderText();
    }

    // public void Build

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            index++;
            RenderText();
        }
    }

    private void RenderText()
    {
        if (index < DialogueSettings.text.Length) {
            dialogueText.text = DialogueSettings.text[index];   
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
