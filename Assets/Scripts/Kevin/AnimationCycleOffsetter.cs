using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCycleOffsetter : MonoBehaviour
{

    //[SerializeField] Animator[] animators;
    [SerializeField] string stateName;

    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach (Animator a in animators)
        {
            a.Play(stateName, 0, Random.Range(0, 1));
            //float randomOffset = Random.Range(0, 1);
        }
        */
        
        this.GetComponent<Animator>().Play(stateName, -1, Random.Range(0, 1));

        /*
         * int randomNumber = Random.Range(1, 4);
            anim.SetTrigger("atk" + randomNumber);
        */
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
