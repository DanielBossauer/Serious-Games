using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DeactivateOtherEditor : MonoBehaviour
{

    [SerializeField] GameObject first;
    [SerializeField] GameObject other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (first.gameObject.activeInHierarchy) other.gameObject.SetActive(false);
        else if (other.gameObject.activeInHierarchy) first.gameObject.SetActive(false);
    }
}
