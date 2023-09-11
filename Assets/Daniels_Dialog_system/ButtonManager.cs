using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject childUIPrefab;

    private void Start()
    {
        SpawnChild();
    }

    public void SpawnChild()
    {
        if (childUIPrefab != null)
        {
            GameObject canvas = GetComponentInParent<Canvas>().gameObject;
            GameObject newChildUI = Instantiate(childUIPrefab, transform);
            newChildUI.transform.position = transform.position;
        }
    }
}
