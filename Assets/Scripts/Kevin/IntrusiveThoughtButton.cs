using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntrusiveThoughtButton : MonoBehaviour
{
    [SerializeField] int clickTimes = 3;
    int remainingClicks;
    float darken;

    public void Awake()
    {
        
    }

    public void OnClick()
    {
        if (remainingClicks==0) remainingClicks = clickTimes;

        darken = 1 / clickTimes;

        remainingClicks -=1;
        if(remainingClicks <= 0)
        {
            //destroy parent and children
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            //Button button = gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<Button>();
            //Color tmpColor = button.colors.normalColor;
            //gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<Button>().colors.normalColor.r = new Color(tmpColor.r-tmpColor.r*darken,tmpColor.g-tmpColor.g*darken,tmpColor.b-tmpColor.b*darken,tmpColor.a);


            Button b = gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<Button>();
            ColorBlock cb = b.colors;
            cb.normalColor = new Color(cb.normalColor.r - cb.normalColor.r * darken, cb.normalColor.g - cb.normalColor.g * darken, cb.normalColor.b - cb.normalColor.b * darken, cb.normalColor.a);
            cb.highlightedColor = new Color(cb.highlightedColor.r - cb.highlightedColor.r * darken, cb.highlightedColor.g - cb.highlightedColor.g * darken, cb.highlightedColor.b - cb.highlightedColor.b * darken, cb.highlightedColor.a);
            
            //b.colors = cb;

            gameObject.transform.parent.gameObject.transform.GetChild(0).GetComponent<Button>().colors = cb;

        }
    }
}
