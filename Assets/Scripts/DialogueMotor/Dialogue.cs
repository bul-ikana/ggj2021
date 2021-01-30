using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue 
{
	public List<MessageStruct> Messages;

	public Dialogue() {
		Messages = new List<MessageStruct>();
	}

	public void Add(int character, string text)
	{
		MessageStruct message = new MessageStruct(character, text);
		Messages.Add(message);
	}
}
