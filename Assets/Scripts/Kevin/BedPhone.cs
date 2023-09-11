using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BedPhone : MonoBehaviour
{

    Material[] myMaterials;

    [SerializeField] Material black;
    [SerializeField] Material white;

    // Start is called before the first frame update
    void Start()
    {
        myMaterials = this.gameObject.GetComponent<MeshRenderer>().materials;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlackScreen()
    {
        if(myMaterials == null)
        {
            myMaterials = this.gameObject.GetComponent<MeshRenderer>().materials;
        }
        myMaterials[1] = black;
        GetComponent<Renderer>().materials = myMaterials;
    }

    public void WhiteScreen()
    {
        if (myMaterials == null)
        {
            myMaterials = this.gameObject.GetComponent<MeshRenderer>().materials;
        }
        myMaterials[1] = white;
        GetComponent<Renderer>().materials = myMaterials;
    }
}
