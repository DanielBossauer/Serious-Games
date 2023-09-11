using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dialogs
{

    public DialogueObject startDialogueQuestions = new DialogueObject(new string[] {
                "I'm sorry I'm not as pretty as other girls.",
                "I know I'm not your first choice. You'd probably rather be with someone better.",
                "I hope we can still have a good time together, even if you might find someone better.",
                "I apologize for not having any hobbies to talk about.",
                "I'm sorry if there's someone else you'd rather be here with.",
                "Do you think being more confident would make a difference?",
                "I'm sorry I was late.",
                "I'm sorry if I somehow acted inappropriately. I don't always realize it.",
                "Why can't the world be like a dating sim, where the answers are always obvious?",
                "Oh, you probably wouldn't like me if you saw me at home.",
                "I'm sorry for talking too much."},
                true);

    public DialogObjectPath startDialog = new DialogObjectPath(
        new DialogueObject[] {
            new DialogueObject(new string[]{"sorry I am Late.", "I hope you didn't have to wait long."}),
            new DialogueObject(new string[] {"Oh it's OK. I also arrived a short time ago"}, false, true, "Date"),
            null
        },
        null);

    DialogObjectPath[] startQuestionsAnswers;

    public dialogs()
    {
        DialogueObject[] objs = startDialog.dialogObjects;
        objs[objs.Length-1] = startDialogueQuestions;
        makeDepressionQuestionsAnswers();
        startDialog.choicePaths = startQuestionsAnswers;
    }

    public DialogObjectPath GetNewPath(int i)
    {
        return startQuestionsAnswers[i];
    }

    string[] ChooseStringsFromColumns()
    {
        string[][] dialogChoicesList = new string[][] {
            new string[] {
                "Everyone is worth being loved, and personally, I find you very kind. Even mean or unlikable people still find love, so what makes you so bad that no one could love you?",
                "Yes, I feel that way sometimes too, but it passes.",
                "You shouldn't say that if you want to find a partner.",
                "Oh"
            }, 
            new string[] {
                "Even though I don't necessarily see it that way, I don't think a few extra pounds define a person. What matters is that you're content with yourself, and if you're not, that's okay; you can work on it. Your appearance and how people perceive you don't solely depend on your looks.",
                "Nowadays, I think girls are too thin anyway. I find girls with curves much more attractive.",
                "It could be worse. Let me tell you about my last date...",
                "..."
            }, 
            new string[] {
                "I don't think that at all. I wouldn't have gone on a date with you if I didn't find you at least somewhat attractive.",
                "I actually prefer that you're not too pretty. Really beautiful girls make me feel shy.",
                "Don't worry; you'll be fine. We'll figure it out.",
                "that's sad."
            }, 
            new string[] {
                "Of course, there will always be someone who looks better, but not everyone is looking for a supermodel or a fashion queen. Most people, I would say, prefer someone they can be themselves with. Looks are not as important as everyone thinks.",
                "Yes, but it's as if I don't stand a chance with them.",
                "That's okay too. I actually prefer being the smarter one in a relationship.",
                "I am not really in the mood to talk about something like this."
            }, new string[]
            {
                "It's hard for me to imagine leaving my girlfriend just because I found someone I get along with. The reason why people cheat or leave their partners in such situations is often that they were already unhappy about something before. Either in the relationship or with themselves. It's often a sign that something was already wrong before. And if you've been together for a while, the other person doesn't just find someone they get along with better.",
                "You can never know. Maybe everyone has a soulmate they end up with. And maybe your partner will leave you because of that. But maybe you'll find the one in a million.",
                "Do you think I'd be here if I could find someone better?",
                "Oh, not really."
            }, new string[]
            {
                "I've actually enjoyed the evening so far. Maybe you don't have interesting hobbies right now, but I could take you to x/y. You don't always have to do something extraordinary to be interesting. Everyone tries so hard to please the other person that it can be quite refreshing when someone just talks about their day.",
                "I don't have any real hobbies either, so we can just be hobby-less together.",
                "Yes, I actually prefer talking about myself. You can listen to me talking about my hobbies.",
                "No, hobbies you say."
            }, new string[]
            {
                "No, I'm glad I'm here with you. I didn't go on a date with you for no reason.",
                "I'm here because I wanted to see you. No one else. If I made you feel like I wasn't interested in the date, then I'm sorry.",
                "Well, I do sometimes think about my ex, but I've moved on from her.",
                "I don't really talk to my ex anymore."
            }, new string[]
            {
                "It would probably be more enjoyable if you had more confidence. But not because I didn't have fun, but because it's more fun when you just relax and enjoy the moment. Let's just have fun together.",
                "It's not that serious. I'm also really nervous, and that's normal for a first date.",
                "Honestly, I didn't notice, maybe you shouldn't take yourself so seriously. Just have fun.",
                "Sorry"
            }, new string[]
            {
                "Well, maybe the answers are obvious for you, but others probably struggle with it too. I'm sure you weren't an expert at first either, just like dating sims in real life.",
                "Yeah, but I think I'm a bit like a dating sim character too.",
                "I'm sorry, but I'm not really familiar with that. But you're probably right.",
                "Dating Sims, I didn't knew people still play them."
            }, new string[]
            {
                "I'm sure you're enchanting in any setting. We all have unflattering sides, and it shouldn't get to you if you're not perfect. I have some quirky habits that I would never reveal on a first date.",
                "Don't worry; I'm not very picky. You can let your standards drop a bit more before it becomes uncomfortable for me.",
                "Well, I don't expect you to be all made up and freshly showered at home all the time either.",
                "Oh, but you still came to the date?"
            }, new string[]
            {
                "I like that you can talk a lot. It shows that you're interested in many things and that it's essential for you to make me understand what you're about.",
                "No, I'm actually bad at talking. I'm quite happy when you take over this part.",
                "At some point, you'll run out of things to say, and then I can say something. So take your time; it's fine.",
                "I can talk more if you want. ..."
            }
        };

        if (dialogChoicesList == null || dialogChoicesList.Length == 0)
        {
            throw new ArgumentException("dialogChoicesList is null or empty!");
        }

        int numRows = dialogChoicesList.Length;
        int numCols = dialogChoicesList[0].Length;

        string[] chosenStrings = new string[numRows];

        for (int row = 0; row < numRows; row++)
        {
            int randomIndex = UnityEngine.Random.Range(0, numCols);
            chosenStrings[row] = dialogChoicesList[row][randomIndex];
        }
        return chosenStrings;
    }

    private void makeDepressionQuestionsAnswers()
    {
        string[] chosenStrings = ChooseStringsFromColumns();
        startQuestionsAnswers = new DialogObjectPath[chosenStrings.Length];
        for (int i = 0; i < chosenStrings.Length; i++)
        {
            startQuestionsAnswers[i] = new DialogObjectPath(new DialogueObject[] { new DialogueObject(new string[] { chosenStrings[i] }, false, true, "Date"), startDialogueQuestions}, startQuestionsAnswers);
        }
    }
}
