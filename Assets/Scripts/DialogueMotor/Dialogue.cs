using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue 
{
    public List<MessageStruct> Messages;
    public string BackgroundSprite;
    public string Character1Sprite;
    public string Character2Sprite;

    public Dialogue() {
        Messages = new List<MessageStruct>();
    }

    public void SetBackground(string background)
    {
        Debug.Log(background);
        BackgroundSprite = background;
    }

    public void SetCharacter1(string character)
    {
        Character1Sprite = character;
    }

    public void SetCharacter2(string character)
    {
        Character2Sprite = character;
    }

    public void Add(int character, string text)
    {
        MessageStruct message = new MessageStruct(character, text);
        Messages.Add(message);
    }
}
