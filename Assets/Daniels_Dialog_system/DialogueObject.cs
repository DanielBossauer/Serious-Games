public class DialogueObject
{
    public bool speakerRight = true;
    public string[] text;
    public bool multipleAnswers = false;
    public string speakerName;

    public DialogueObject(string[] text, bool multipleAnswers = false, bool speakerRight = false, string name = "Rose")
    {
        this.speakerRight = speakerRight;
        this.speakerName = name;
        this.text = text;
        this.multipleAnswers = multipleAnswers;
    }
}
