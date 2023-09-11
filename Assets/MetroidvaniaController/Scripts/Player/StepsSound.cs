using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepsSound : MonoBehaviour
{
   public GameObject steps;

    void Start()
    {
        steps.SetActive(false);
    }

    // should use Groundcheck and should only call function when speed changes in Silverfish
    void Update()
    {

//        if(Input.GetKeyDown("d") || Input.GetKeyDown("a") || Input.GetKeyDown("right") || Input.GetKeyDown("left"))
        if(GetComponent<PlayerMovement>().currentSpeed > 0f)
        {
            ActivateSteps();
        }


 //       if(Input.GetKeyUp("a") || Input.GetKeyUp("d") || Input.GetKeyUp("right") || Input.GetKeyUp("left"))
        if(GetComponent<PlayerMovement>().currentSpeed == 0f)
        {
            StopSteps();
        }

    }

    void ActivateSteps()
    {
        steps.SetActive(true);
    }

    void StopSteps()
    {
        steps.SetActive(false);
    }

}