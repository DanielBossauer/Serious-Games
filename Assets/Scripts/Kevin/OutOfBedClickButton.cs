using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBedClickButton : MonoBehaviour
{
    //public bool timeUp = false;
    //float timeSinceSpawn;
    //public float timeToClick = 5f;

    public bool energyButton;

    public CantGetOutOfBed cantGetOutOfBed;

    [SerializeField] float maxScale = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        //timeSinceSpawn = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Time.realtimeSinceStartup >= timeSinceSpawn + timeToClick)
        {
            timeUp = true;
        }
        */

        if (GetOwnSize() >= maxScale)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnClick()
    {
        if (energyButton)
        {
            cantGetOutOfBed.EnergyButtonClicked(maxScale - GetOwnSize());
        }
        else
        {
            cantGetOutOfBed.DepressionButtonClicked(GetOwnSize() / maxScale);
        }
        Destroy(this.gameObject);
    }

    float GetOwnSize()
    {
        return this.gameObject.transform.localScale.x;
    }
}
