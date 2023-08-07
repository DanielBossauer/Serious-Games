[System.Serializable]
public class DialogObjectPath
{
    //Das letzte DialogObject muss im Text String genausoviele Elemente haben,
    //wie choicePaths
    public DialogueObject[] dialogObjects;
    public DialogObjectPath[] choicePaths;

    public DialogObjectPath(DialogueObject[] dialogs, DialogObjectPath[] paths)
    {
        dialogObjects = dialogs;
        choicePaths = paths;
    }
}
