public class DialogueObject
{
    public bool speakerRight = true;
    public string[] text;
    public bool multipleAnswers = false;

    public DialogueObject(bool speakerRight, string[] text, bool multipleAnswers)
    {
        this.speakerRight = speakerRight;
        this.text = text;
        this.multipleAnswers = multipleAnswers;
    }
}
