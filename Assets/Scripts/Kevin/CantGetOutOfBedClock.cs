using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CantGetOutOfBedClock : MonoBehaviour
{
    CantGetOutOfBed connector;
    TextMeshProUGUI tmPro;

    float timeSinceLastClockUpdate;
    public float updateTime = 200f;

    bool running;

    float currentClockDisplayTime;

    public bool crazyClockOn;

    float initUpdateTime;

    // Start is called before the first frame update
    void Start()
    {
        initUpdateTime = updateTime;
    }

    public void SetSpeed(float speed)
    {
        updateTime *= 1/speed; 
    }

    public void ResetSpeed()
    {
        updateTime = initUpdateTime;
    }

    public float GetTimeAsDecimalFloat()
    {
        float decimalPart = currentClockDisplayTime % 1;
        float partBeforeDecimal = Mathf.Floor(currentClockDisplayTime);
        decimalPart *= 100/60;
        return partBeforeDecimal + decimalPart;
    }

    // Update is called once per frame
    void Update()
    {
        if (running && !crazyClockOn)
        {
            if (Time.realtimeSinceStartup > timeSinceLastClockUpdate + updateTime)
            {
                timeSinceLastClockUpdate = Time.realtimeSinceStartup;

                currentClockDisplayTime += 0.01f;
                float decimalPart = currentClockDisplayTime % 1;
                if (decimalPart >= 0.6) currentClockDisplayTime = currentClockDisplayTime + 1f - decimalPart;
                if (currentClockDisplayTime >= 24f) currentClockDisplayTime = 0f;
                SetTime(currentClockDisplayTime);
            }
        }

        if (running && crazyClockOn)
        {
            if (Time.realtimeSinceStartup > timeSinceLastClockUpdate + updateTime)
            {
                timeSinceLastClockUpdate = Time.realtimeSinceStartup;

                currentClockDisplayTime += 0.01f;
                float decimalPart = currentClockDisplayTime % 1;
                if (decimalPart >= 0.6) currentClockDisplayTime = currentClockDisplayTime + 1f - decimalPart;
                if (currentClockDisplayTime >= 24f) currentClockDisplayTime = 0f;
                CrazySetTime(currentClockDisplayTime);
            }
        }
    }

    public void Run(CantGetOutOfBed thingy)
    {
        connector = thingy;
        tmPro = this.gameObject.GetComponent<TextMeshProUGUI>();

        timeSinceLastClockUpdate = Time.realtimeSinceStartup;

        this.gameObject.SetActive(true);

        running = true;
    }

    //float time: in military time (00.00f up to 23.59f)
    public void SetTime(float time)
    {
        currentClockDisplayTime = time;

        float decimalPart = time % 1;
        if (decimalPart >= 0.6) time = time + 1f - decimalPart;
        if (time >= 24f) time = 0f;
        

        if (time < 10f)
        {
            //0 + part before decimal + : + part after decimal
            if (time % 1 < 0.1f)
            {
                tmPro.text = "0" + Mathf.FloorToInt(time) + ":0" + GetMinutesOfClock(time);
            }
            else
            {
                tmPro.text = "0" + Mathf.FloorToInt(time) + ":" + GetMinutesOfClock(time);
            }

            tmPro.text += " AM";
            
        }
        else if (time >= 10f && time < 13f)
        {
            if (time % 1 < 0.1f)
            {
                tmPro.text = Mathf.FloorToInt(time) + ":0" + GetMinutesOfClock(time);
            }
            else
            {
                tmPro.text = Mathf.FloorToInt(time) + ":" + GetMinutesOfClock(time);
            }

            tmPro.text += " AM";
        }

        else if (time >= 13f && time < 22f)
        {
            int tmp = Mathf.FloorToInt(time) - 12;
            if (time % 1 < 0.1f)
            {
                
                tmPro.text = "0" + tmp + ":0" + GetMinutesOfClock(time);
            }
            else
            {
                tmPro.text = "0" + tmp + ":" + GetMinutesOfClock(time);
            }

            tmPro.text += " PM";
        }
        else
        {
            int tmp = Mathf.FloorToInt(time) - 12;
            if (time % 1 < 0.1f)
            {
                tmPro.text = tmp + ":0" + GetMinutesOfClock(time);
            }
            else
            {
                tmPro.text = tmp + ":" + GetMinutesOfClock(time);
            }

            tmPro.text += " PM";
        }
        
    }

    int GetMinutesOfClock(float time)
    {
        float tmp = time % 1;
        tmp *= 100;
        return Mathf.FloorToInt(tmp);
    }


    //float time: in military time (00.00f up to 23.59f)
    public void CrazySetTime(float time)
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

    public void Stop()
    {
        running = false;
        this.gameObject.SetActive(false);
    }

    public bool IsNightTime()
    {
        if(currentClockDisplayTime > 22f || currentClockDisplayTime < 6f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
