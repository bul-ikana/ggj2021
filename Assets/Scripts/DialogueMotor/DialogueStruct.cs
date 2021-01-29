/**
 * This struct represents a single piece of dialogue said by one of the two characters
 * involved in the conversation.
 *
 * Character is an integer representing who is talking the dialogue. 0 is the 
 * main character (aka the player) and 1 (or higher) is the other player.
 * 
 * Text is a string with the text that will be shown on the dialogue box
 */
public struct DialogueStruct
{
    public int Character;
    public string Text;

    public DialogueStruct (
        int character,
        string text
    ) {
        Character = character;
        Text = text;
    }
}
