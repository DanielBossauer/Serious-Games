using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CantGetOutOfBedClock : MonoBehaviour
{
    CantGetOutOfBed connector;
    TextMeshProUGUI tmPro;

    float timeSinceLastClockUpdate;
    [SerializeField] float updateTime = 0.25f;

    bool running;

    float currentClockDisplayTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            if (Time.realtimeSinceStartup > timeSinceLastClockUpdate + updateTime)
            {
                currentClockDisplayTime += 0.01f;
                float decimalPart = currentClockDisplayTime % 1;
                if (decimalPart >= 60) currentClockDisplayTime = currentClockDisplayTime + 1f - decimalPart;
                if (currentClockDisplayTime >= 24f) currentClockDisplayTime = 0f;
                SetTime(currentClockDisplayTime);
            }
        }
    }

    public void Run(CantGetOutOfBed thingy)
    {
        connector = thingy;
        tmPro = this.gameObject.GetComponent<TextMeshProUGUI>();

        timeSinceLastClockUpdate = Time.realtimeSinceStartup;

        running = true;
    }

    //float time: in military time (00.00f up to 23.59f)
    public void SetTime(float time)
    {
        float decimalPart = time % 1;
        if (decimalPart >= 60) time = time + 1f - decimalPart;
        if (time >= 24f) time = 0f;
        

        if (time < 10f)
        {
            //0 + part before decimal + : + part after decimal
            if (time % 1 < 0.1f)
            {
                tmPro.text = "0" + Mathf.FloorToInt(time) + ":0" + time % 1;
            }
            else
            {
                tmPro.text = "0" + Mathf.FloorToInt(time) + ":" + time % 1;
            }

            tmPro.text += " AM";
            
        }
        else if (time >= 10f && time < 13f)
        {
            if (time % 1 < 0.1f)
            {
                tmPro.text = Mathf.FloorToInt(time) + ":0" + time % 1;
            }
            else
            {
                tmPro.text = Mathf.FloorToInt(time) + ":" + time % 1;
            }

            tmPro.text += " AM";
        }

        else if (time >= 13f && time < 22f)
        {
            int tmp = Mathf.FloorToInt(time) - 12;
            if (time % 1 < 0.1f)
            {
                
                tmPro.text = "0" + tmp + ":0" + time % 1;
            }
            else
            {
                tmPro.text = "0" + tmp + ":" + time % 1;
            }

            tmPro.text += " PM";
        }
        else
        {
            int tmp = Mathf.FloorToInt(time) - 12;
            if (time % 1 < 0.1f)
            {
                tmPro.text = tmp + ":0" + time % 1;
            }
            else
            {
                tmPro.text = tmp + ":" + time % 1;
            }

            tmPro.text += " PM";
        }
        
    }
}
