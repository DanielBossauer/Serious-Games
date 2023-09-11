using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwapMinigameButton : MonoBehaviour
{
    [SerializeField] SwapMinigame swapMinigame;

    bool isSelected;

    bool clickable;

    [SerializeField] public int rightPosition;

    int currentPosition;

    //[SerializeField] int rightNumber;

    private void Awake()
    {
        currentPosition = rightPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedOnButton()
    {
        if (clickable)
        {
            if (!isSelected)
            {
                Select();
            }
            else
            {
                Deselect();
            }
            
        }
        
    }

    public void MakeClickable()
    {
        clickable = true;
        SetCurrentPosition(currentPosition);
    }

    public void MakeUnClickable()
    {
        clickable = false;
    }

    public void Select()
    {
        
        isSelected = true;

        this.GetComponent<Image>().color = new Color(0.45f, 0.3f, 0.3f);

        swapMinigame.ButtonClicked(this);
    }

    public void Deselect()
    {
        
        isSelected = false;

        this.GetComponent<Image>().color = new Color(1f, 1f, 1f);

        swapMinigame.NullifyButton(this);
    }

    public bool CheckPosition()
    {
        //accept several combinations that are similar to the "correct" solution
        if (rightPosition == currentPosition)
        {
            return true;
        }
        else if(rightPosition == 7 && (currentPosition == 8 || currentPosition == 9))
        {
            return true;
        }
        else if (rightPosition == 8 && (currentPosition == 7 || currentPosition == 9))
        {
            return true;
        }
        else if (rightPosition == 9 && (currentPosition == 7 || currentPosition == 8))
        {
            return true;
        }

        return false;
    }

    public void SetCurrentPosition(int i)
    {
        //if (i == 0) i = rightPosition;
        currentPosition = i;
        this.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = i.ToString();
    }

    public int GetCurrentPosition()
    {
        return currentPosition;
    }
}
