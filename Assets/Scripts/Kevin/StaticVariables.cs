using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVariables
{

    public static Dictionary<string, string> notebookDict { get; set; }

    public static Dictionary<string, string> GetNotebookDict()
    {
        return notebookDict;
    }

    /*
    public static void SetNotebookDict(Dictionary<string, string> notebookDict)
    {
        this.notebookDict = notebookDict;
    }
    */
}
