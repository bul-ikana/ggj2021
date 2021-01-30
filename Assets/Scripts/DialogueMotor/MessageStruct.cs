/**
 * This struct represents a single message said by one of the two characters involved in the dialogue.
 *
 * Character is an integer representing who is talking the message. 0 is the 
 * main character (aka the player) and 1 (or higher) is the other player.
 * 
 * Text is a string with the text that will be shown on the dialogue box
 */
public struct MessageStruct
{
    public int Character;
    public string Text;

    public MessageStruct (
        int character,
        string text
    ) {
        Character = character;
        Text = text;
    }
}
