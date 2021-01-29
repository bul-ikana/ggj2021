using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogueMotor
{
    public static DialogueStruct[] Dialogue;

    public static void SetDialogue(DialogueStruct[] dialogue)
    {
        Dialogue = dialogue;
    }
}
