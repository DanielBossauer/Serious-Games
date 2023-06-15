using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraFromToWhenTriggerd : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam1.enabled = (true);
        cam2.enabled = (false);
    }
}
