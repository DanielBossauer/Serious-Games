using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BedEnergyBar : MonoBehaviour
{
    float energyValue;

    //[SerializeField] bool debugTextOn;

    GameObject child;

    

    private void Awake()
    {
        //child = this.gameObject.transform.GetChild(0).gameObject;

        child = this.gameObject.transform.GetChild(2).gameObject;
    }

    private void Update()
    {
        /*
        if (debugTextOn)
        {
            child.SetActive(true);
            child.transform.GetComponent<TextMeshProUGUI>().text = energyValue.ToString();
        }
        else
        {
            child.gameObject.SetActive(false);
        }
        */


        child.transform.GetComponent<Image>().fillAmount = energyValue;
    }

    public float GetValue()
    {
        CheckValue();
        return energyValue;
    }

    public void IncreaseValue(float value)
    {
        energyValue += value;
        CheckValue();
    }

    public void DecreaseValue(float value)
    {
        energyValue -= value;
        CheckValue();
    }

    void CheckValue()
    {
        if(energyValue > 1)
        {
            energyValue = 1f;
        }

        if(energyValue < 0)
        {
            energyValue = 0f;
        }
    }
}
