using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class IntrusiveThoughtManager : MonoBehaviour
{
    
    [SerializeField] GameObject intrusiveThoughtBubble;
    [SerializeField] Camera givenCamera;
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeThoughtAppear(string text = "default")
    {
        //Color color = new Color();
        //if (colorArr != null) color = new Color(colorArr[0], colorArr[1], colorArr[2], colorArr[3]);
        //else color = new Color(0, 0, 0, 0);

        float UIPlaneZDepth = 10; //change as needed 
        Debug.Log(Screen.width * 0.1f);
        Debug.Log(Screen.width - Screen.width * 0.1f);
        Debug.Log(Screen.height * 0.1f);
        Debug.Log(Screen.height - Screen.height * 0.1f);
        //Vector3 randomScreenPos = new Vector3(Random.Range(Screen.width * 0.1f, Screen.width - Screen.width * 0.1f), Random.Range(Screen.height * 0.1f, Screen.height - Screen.height * 0.1f), Random.Range(UIPlaneZDepth, UIPlaneZDepth + 14));
        //Vector3 randomWorldPos = givenCamera.ScreenToWorldPoint(randomScreenPos);
        //Vector3 randomScreenPos = new Vector3(Random.Range(-300f, 300f), Random.Range(-200f, 200f), Random.Range(UIPlaneZDepth, UIPlaneZDepth + 14)); ;
        //Vector3 randomWorldPos = givenCamera.ScreenToWorldPoint(randomScreenPos);
        Vector3 randomWorldPos = new Vector3(Random.Range(Screen.width * 0.1f, Screen.width - Screen.width * 0.1f), Random.Range(Screen.height * 0.1f, Screen.height - Screen.height * 0.1f), 0);


        GameObject myBubble = Instantiate(intrusiveThoughtBubble, randomWorldPos, Quaternion.identity) as GameObject;
        myBubble.gameObject.transform.SetParent(canvas.transform);
        //myBubble.GetComponent<RectTransform>().position = randomWorldPos;

        TextMeshProUGUI textMeshPro = myBubble.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textMeshPro.text = text;
        //textMeshPro.color = color;
        //textMeshPro.font = font;
        //textMeshPro.enableAutoSizing = true;
        //if (fontStyle == "bold") textMeshPro.fontStyle = FontStyles.Bold;
        StartCoroutine(GrowInSize(myBubble, 0.1f));
    }

    public void MakeThoughtAppear(string text = "", int[] colorArr = null, string font = "default", string fontStyle = "", float growFactor = 1f)
    {
        Color color = new Color();
        if (colorArr != null) color = new Color(colorArr[0], colorArr[1], colorArr[2], colorArr[3]);
        else color = new Color(0, 0, 0, 0); 

        float UIPlaneZDepth = 10; //change as needed 
        Vector3 randomScreenPos = new Vector3(Random.Range(Screen.width*0.1f, Screen.width- Screen.width*0.1f), Random.Range(Screen.height*0.1f, Screen.height - Screen.height*0.1f), Random.Range(UIPlaneZDepth, UIPlaneZDepth + 14));
        Vector3 randomWorldPos = givenCamera.ScreenToWorldPoint(randomScreenPos);

        GameObject myBubble = Instantiate(intrusiveThoughtBubble, randomWorldPos, Quaternion.identity) as GameObject;
        myBubble.gameObject.transform.parent = canvas.transform;

        TextMeshPro textMeshPro = myBubble.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshPro>();
        textMeshPro.text = text;
        textMeshPro.color = color;
        //textMeshPro.font = font;
        textMeshPro.enableAutoSizing = true;
        if(fontStyle == "bold") textMeshPro.fontStyle = FontStyles.Bold;
        StartCoroutine(GrowInSize(myBubble, growFactor));
    }

    IEnumerator GrowInSize(GameObject bubble, float growFactor = 0.11f)
    {
        while (bubble != null)
        {
            Vector3 localScale = bubble.gameObject.transform.localScale;
            float growth = 1 + growFactor * Time.deltaTime;
            bubble.gameObject.transform.localScale = new Vector3(localScale.x * growth, localScale.y * growth, localScale.z * growth);
            bubble.gameObject.transform.position = new Vector3(bubble.transform.position.x + Random.Range(0, 1) * Time.deltaTime, bubble.transform.position.y + Random.Range(0, 1) * Time.deltaTime, bubble.transform.position.z);
            yield return new WaitForEndOfFrame();
        }
       
    }
}
