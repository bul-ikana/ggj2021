using UnityEngine.SceneManagement;

public static class DialogueMotor
{
    public static int CurrentScene;
    public static Dialogue CurrentDialogue;

    public static void GoToDialogue(Dialogue dialogue)
    {
        CurrentDialogue = dialogue;
        SceneManager.LoadSceneAsync("Dialogue", LoadSceneMode.Additive);
    }
}
