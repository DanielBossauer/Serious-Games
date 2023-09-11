
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
    [SerializeField] GameObject indestructableBubble;

    [SerializeField] OutOfBedClickButton energyButtonPrefab;
    [SerializeField] OutOfBedClickButton depressionButtonPrefab;

    [SerializeField] string[] depressionTexts;

    List<GameObject> spawnedBubbles;
    [SerializeField] bool keepTrackOfSpawnedBubbles;

    public void Update()
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

        if(keepTrackOfSpawnedBubbles) spawnedBubbles.Add(myBubble);
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

        if (keepTrackOfSpawnedBubbles) spawnedBubbles.Add(myBubble);
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

    public void ItsUseless()
    {
        MakeThoughtAppear("I T ' S    U S E L E S S", Color.red);
    }

    public void MakeThoughtAppear(string text, Color color)
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
        textMeshPro.color = color;
        //textMeshPro.font = font;
        //textMeshPro.enableAutoSizing = true;
        //if (fontStyle == "bold") textMeshPro.fontStyle = FontStyles.Bold;
        StartCoroutine(GrowInSize(myBubble, 0.1f));

        if (keepTrackOfSpawnedBubbles) spawnedBubbles.Add(myBubble);
    }

    public void IndestructableBubble()
    {
        //float UIPlaneZDepth = 10;

        Vector3 worldPos = new Vector3(Screen.width*0.5f, Screen.height*0.9f, 0);

        GameObject myBubble = Instantiate(indestructableBubble, worldPos, Quaternion.identity) as GameObject;
        myBubble.gameObject.transform.SetParent(canvas.transform);
        TextMeshProUGUI textMeshPro = myBubble.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "Y O U   S H O U L D   H A V E   K I L L E D   Y O U R S E L F    A L R E A D Y";
        textMeshPro.color = Color.red;

        StartCoroutine(GrowInSize(myBubble, 0.1f));
        StartCoroutine(DestroyAfterTime(5f,myBubble));

        if (keepTrackOfSpawnedBubbles) spawnedBubbles.Add(myBubble);
    }

    public void MessengerBubbles(string text)
    {
        Vector3 worldPos = new Vector3(Screen.width * 0.5f, Screen.height * 0.25f, 0);

        GameObject myBubble = Instantiate(intrusiveThoughtBubble, worldPos, Quaternion.identity) as GameObject;
        myBubble.gameObject.transform.SetParent(canvas.transform);
        TextMeshProUGUI textMeshPro = myBubble.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textMeshPro.text = text;
        textMeshPro.color = Color.red;

        StartCoroutine(SpreadInRandomDirection(myBubble));
        StartCoroutine(DestroyAfterTime(4f, myBubble));

        if (keepTrackOfSpawnedBubbles) spawnedBubbles.Add(myBubble);
    }

    IEnumerator SpreadInRandomDirection(GameObject myBubble)
    {

        Vector3 speed = new Vector3(Random.Range(-10f,10f), Random.Range(-10f, 10f), 0f);

        while (myBubble != null)
        {
            myBubble.gameObject.transform.position += speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator DestroyAfterTime(float time, GameObject bubble)
    {
        yield return new WaitForSeconds(time);
        Destroy(bubble);
    }



    //CANTGETOUTOFBEDMINIGAME
    public OutOfBedClickButton MakeEnergyButtonAppear()
    {
        

        Vector3 randomWorldPos = new Vector3(Random.Range(Screen.width * 0.1f, Screen.width - Screen.width * 0.1f), Random.Range(Screen.height * 0.1f, Screen.height - Screen.height * 0.1f), 0);


        OutOfBedClickButton tmp = Instantiate(energyButtonPrefab,randomWorldPos,Quaternion.identity);
        tmp.gameObject.transform.SetParent(canvas.transform);

        tmp.energyButton = true;

        //TextMeshProUGUI textMeshPro = tmp.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        //textMeshPro.text = text;
        //textMeshPro.color = color;
        //textMeshPro.font = font;
        //textMeshPro.enableAutoSizing = true;
        //if (fontStyle == "bold") textMeshPro.fontStyle = FontStyles.Bold;
        StartCoroutine(GrowInSize(tmp.gameObject, 0.1f));

        if (keepTrackOfSpawnedBubbles) spawnedBubbles.Add(tmp.gameObject);

        return tmp;
    }

    public OutOfBedClickButton MakeDepressionButtonAppear()
    {
        Vector3 randomWorldPos = new Vector3(Random.Range(Screen.width * 0.1f, Screen.width - Screen.width * 0.1f), Random.Range(Screen.height * 0.1f, Screen.height - Screen.height * 0.1f), 0);


        OutOfBedClickButton tmp = Instantiate(depressionButtonPrefab, randomWorldPos, Quaternion.identity);
        tmp.gameObject.transform.SetParent(canvas.transform);

        TextMeshProUGUI textMeshPro = tmp.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textMeshPro.text = depressionTexts[Random.Range(0,depressionTexts.Length)];

        tmp.energyButton = false;

        StartCoroutine(GrowInSize(tmp.gameObject, 0.1f));

        if (keepTrackOfSpawnedBubbles) spawnedBubbles.Add(tmp.gameObject);

        return tmp;
    }

    void SetSize(GameObject bubble, Vector3 newLocalScale)
    {
        //Vector3 localScale = bubble.gameObject.transform.localScale;
        //float growth = 1 + growFactor * Time.deltaTime;
        bubble.gameObject.transform.localScale = newLocalScale;
        //bubble.gameObject.transform.position = new Vector3(bubble.transform.position.x + Random.Range(0, 1) * Time.deltaTime, bubble.transform.position.y + Random.Range(0, 1) * Time.deltaTime, bubble.transform.position.z);

    }

    public void KeepTrackOfSpawnedBubbles(bool b)
    {
        keepTrackOfSpawnedBubbles = b;
        if (spawnedBubbles == null) spawnedBubbles = new List<GameObject>();
    }

    public void DeleteAllThoughts()
    {
        foreach (GameObject s in spawnedBubbles)
        {
            if (s != null) Destroy(s);
        }
        spawnedBubbles.Clear();
    }

    bool spawnIntrusiveThoughts;

    public IEnumerator SpawnIntrusiveThoughts()
    {
        KeepTrackOfSpawnedBubbles(true);
        spawnIntrusiveThoughts = true;

        while (spawnIntrusiveThoughts)
        {
            MakeThoughtAppear(depressionTexts[Random.Range(0, depressionTexts.Length)]);
            yield return new WaitForSeconds(2);
        }
    }

    public void StopSpawning()
    {
        spawnIntrusiveThoughts = false;
        DeleteAllThoughts();
    }
}
