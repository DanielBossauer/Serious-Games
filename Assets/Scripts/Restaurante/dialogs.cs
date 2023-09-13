using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dialogs
{
    string dialogLine;
    int dialogNum;
    int counts = 0;

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
                "I'm sorry for talking too much."}, true);

    public DialogueObject RestRosaStartDialoge = new DialogueObject(new string[]
    {
        "How are you?",
        "How was your day?",
        "It's late I have to go."
    }, true);

    public DialogueObject KiraAnswers = new DialogueObject(new string[] {
        "Everything will be fine",
        "That's just in your head"
    }, true);

    public DialogObjectPath startDialog = new DialogObjectPath(
        new DialogueObject[] {
            new DialogueObject(new string[]{"sorry I am Late.", "I hope you didn't have to wait long."}),
            new DialogueObject(new string[] {"Oh it's OK. I also arrived a short time ago"}, false, true, "Date"),
            null
        },
        null);

    public DialogObjectPath startHome = new DialogObjectPath(
        new DialogueObject[] {
            new DialogueObject(new string[]{"Finally Home! This was embarrassing."}),
            new DialogueObject(new string[]{"Ring, Ring"}, false, true, "Phone"),
            new DialogueObject(new string[]{"Oh, no he calls."}),
            null,
        }, null);

    public DialogObjectPath selfDepression = new DialogObjectPath(
        new DialogueObject[] {
            null
        }, null);

    DialogObjectPath[] startQuestionsAnswers;

    DialogObjectPath won = new DialogObjectPath(
        new DialogueObject[]
        {
            new DialogueObject(new string[]{"Maybe it is Ok to answer the call. I don't find any reason at the moment not to call."})
        }, null);

    DialogObjectPath HomeLast = new DialogObjectPath(
    new DialogueObject[]
    {
        new DialogueObject(new string[]{"Ring!Ring!"}),
        new DialogueObject(new string[]{"Go to next Date"}, true)
    }, null);

    public dialogs()
    {
        Debug.Log("Visit Debug 2");
        DialogueObject[] objs = startDialog.dialogObjects;
        objs[objs.Length - 1] = RestRosaStartDialoge;

        objs = startHome.dialogObjects;
        string dialogObjectsString = startDialogueQuestions.text[UnityEngine.Random.Range(0, startDialogueQuestions.text.Length)];
        objs[objs.Length - 1] = new DialogueObject(new string[] {dialogObjectsString});

        startQuestionsAnswers = makeQuestionsAnswers(restaurantDateAnswers, RestRosaStartDialoge, false, true, "Date");
        fillQuestionAnswers(startQuestionsAnswers, startQuestionsAnswers);
        startQuestionsAnswers[2] = startHome;
        startDialog.choicePaths = startQuestionsAnswers;

        HomeLast.choicePaths = new DialogObjectPath[] { startDialog };
    }

    public DialogObjectPath GetStartDialog()
    {
        return startDialog;
    }

    public DialogObjectPath kirasAnswer(string line)
    {

        Debug.Log(line);
        string dialogObjectsString = startDialogueQuestions.text[UnityEngine.Random.Range(0, startDialogueQuestions.text.Length)];
        if (counts == 3) {
            counts= 0;
            startQuestionsAnswers = makeQuestionsAnswers(restaurantDateAnswers, RestRosaStartDialoge, false, true, "Date");
            fillQuestionAnswers(startQuestionsAnswers, startQuestionsAnswers);
            startQuestionsAnswers[2] = startHome;
            return HomeLast;
        }
        counts++;
        if (dialogLine == null)
        {
            dialogLine = line;
            for(int i = 0; i < startDialogueQuestions.text.Length; i++)
            {
                if (line == startDialogueQuestions.text[i])
                {
                    dialogNum = i;
                }
            }
            return new DialogObjectPath(new DialogueObject[] { KiraAnswers }, null);
        }
        if (line != dialogLine)
        {
            dialogLine = null;
            if (startDialogueQuestions.text == null)
            {
                return won;
            }
            string[] str = new string[RestRosaStartDialoge.text.Length+1];
            for (int i = 0; i < str.Length; i++)
            {
                if (i != RestRosaStartDialoge.text.Length)
                {
                    str[i] = RestRosaStartDialoge.text[i];
                } else { str[i] = startDialogueQuestions.text[dialogNum]; }
                 
            }
            RestRosaStartDialoge.text = str;
            string[][] strr = new string[restaurantDateAnswers.Length + 1][];
            for (int i = 0; i < str.Length; i++)
            {
                if (i != restaurantDateAnswers.Length)
                {
                    strr[i] = restaurantDateAnswers[i];
                }
                else
                {
                    strr[i] = depressionAnswersStrings[dialogNum];
                }
            }
            restaurantDateAnswers = strr;

            DialogObjectPath[] dop = new DialogObjectPath[startQuestionsAnswers.Length+1];
            for (int i = 0; i < startQuestionsAnswers.Length; i++)
            {
                Debug.Log(startQuestionsAnswers[i]);
                if (i != startQuestionsAnswers.Length)
                {

                    dop[i] = startQuestionsAnswers[i];
                }
                else { dop[i] = startQuestionsAnswers[dialogNum]; }

            }
            startQuestionsAnswers = dop;

            selfDepression.dialogObjects[0] = new DialogueObject(new string[] { dialogObjectsString });
            return selfDepression;
        } else {
            dialogLine = null;
            string[] str = new string[RestRosaStartDialoge.text.Length - 1];
            for (int i = 0; i < str.Length; i++)
            {
                if (i != dialogNum)
                {
                    str[i] = RestRosaStartDialoge.text[i];
                }

            }
            RestRosaStartDialoge.text = str;

            DialogObjectPath[] dop = new DialogObjectPath[startQuestionsAnswers.Length + 1];
            for (int i = 0; i < dop.Length; i++)
            {
                if (i != dialogNum)
                {
                    dop[i] = startQuestionsAnswers[i];
                }

            }
            startQuestionsAnswers = dop;

            selfDepression.dialogObjects[0] = new DialogueObject(new string[] { dialogObjectsString });
            return selfDepression;
        }
    }

    void fillQuestionAnswers(DialogObjectPath[] questionsAnswers, DialogObjectPath[] ToFill)
    {
        for(int i =0; i < questionsAnswers.Length; i++)
        {
            questionsAnswers[i].choicePaths= ToFill;
        }
    }

    string[][] restaurantDateAnswers = new string[][]
    {
            new string[] {
                "Good",
                "Ok",
                "It's rough now"
            },
            new string[] {
                "I met a good friend",
                "I was so exited to meet you",
                "I had a rough day"
            },
            new string[] {
                "bye"
            }
    };

    string[][] depressionAnswersStrings = new string[][] {
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

    private DialogObjectPath[] makeQuestionsAnswers(string[][] chosenStrings, DialogueObject nextDialog, bool mult, bool rightTag, string name)
    {
        int numRows = chosenStrings.Length;

        string[] toAdd = new string[numRows];

        for (int row = 0; row < numRows; row++)
        {
            int numCols = chosenStrings[row].Length;
            int randomIndex = UnityEngine.Random.Range(0, numCols);
            toAdd[row] = chosenStrings[row][randomIndex];
        }
        DialogObjectPath[] QuestionsAnswers = new DialogObjectPath[chosenStrings.Length];
        for (int i = 0; i < chosenStrings.Length; i++)
        {
            QuestionsAnswers[i] = new DialogObjectPath(new DialogueObject[] { new DialogueObject(new string[] { toAdd[i] }, mult, rightTag, name), nextDialog}, startQuestionsAnswers);
        }
        return QuestionsAnswers;
    }
}
