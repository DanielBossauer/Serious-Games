using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstMemoryWithoutThoughts : MonoBehaviour, IEventSystemHandler
{

    [SerializeField] GameObject secondConversant;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MeetNana()
    {
        secondConversant.SetActive(true);
    }
}
