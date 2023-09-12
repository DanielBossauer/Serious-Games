using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StringSaver : MonoBehaviour
{

    Dictionary<string, string> savedStrings;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        this.gameObject.SetActive(true);
        DontDestroyOnLoad(this.gameObject);
    }

    public void SaveText(string s)
    {
        if (savedStrings == null) savedStrings = new Dictionary<string, string>();
        savedStrings.Add(SceneManager.GetActiveScene().name, s);
    }

    public Dictionary<string, string> GetTexts()
    {
        if (savedStrings != null) return savedStrings;
        else
        {
            savedStrings = new Dictionary<string, string>();
            return savedStrings;
        }
    }
}
