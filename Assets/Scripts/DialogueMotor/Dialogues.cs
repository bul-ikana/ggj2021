/**
 *  This class contains all dialogue definitions. All dialogues
 * should be created and edited from here.
 */
public static class Dialogues
{
    public static Dialogue greetings;
    public static Dialogue lupita;

    static Dialogues()
    {
        Dialogues.greetings = new Dialogue();
        Dialogues.greetings.SetBackground("bg2");
        Dialogues.greetings.SetCharacter1("character1");
        Dialogues.greetings.SetCharacter2("character2");
        Dialogues.greetings.Add(0, "Hey dude!");
        Dialogues.greetings.Add(1, "Wassap");
        Dialogues.greetings.Add(0, "Not much dawg");

        Dialogues.lupita = new Dialogue();
        Dialogues.lupita.SetBackground("bg1");
        Dialogues.lupita.SetCharacter1("character2");
        Dialogues.lupita.SetCharacter2("character3");
        Dialogues.lupita.Add(0, "Que le pasa a esa niña?");
        Dialogues.lupita.Add(1, "No se");
        Dialogues.lupita.Add(0, "Que es lo que quiere?");
        Dialogues.lupita.Add(1, "Bailar!");
    }
}
