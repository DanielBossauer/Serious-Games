using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordsAppearingObjects : MonoBehaviour
{
    LerpManager lerpManager;
    WordsAppearingMinigame wordsAppearingMinigame;

    bool isCorrect = false;

    string text;

    float fadeDuration = 3f;

    bool fadeIn;

    bool fadeOut;

    float timeToPass;

    float lastTime;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeIn)
        {
            //this.Rect.GetComponent<Image>().canvasRenderer.SetAlpha(0.01f);
            this.GetComponent<Image>().CrossFadeAlpha(1f, fadeDuration, false);
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().CrossFadeAlpha(1f, fadeDuration, false);
            if (Time.realtimeSinceStartup > lastTime + timeToPass)
            {
                lastTime = Time.realtimeSinceStartup;
                fadeIn = false;
                fadeOut = true;
            }
        }

        if (fadeOut)
        {
            this.GetComponent<Image>().CrossFadeAlpha(0f, fadeDuration, false);
            this.transform.GetChild(0).GetComponent<TextMeshProUGUI>().CrossFadeAlpha(0f, fadeDuration, false);
            if (Time.realtimeSinceStartup > lastTime + timeToPass)
            {
                fadeIn = false;
                fadeOut = false;
                wordsAppearingMinigame.RemoveObjectOutOfInternal(this);
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator GrowBigger(float growFactor = 0.1f)
    {
        while (this.gameObject != null)
        {
            Vector3 localScale = this.gameObject.transform.localScale;
            float growth = 1 + growFactor * Time.deltaTime;
            this.gameObject.transform.localScale = new Vector3(localScale.x * growth, localScale.y * growth, localScale.z * growth);
            this.gameObject.transform.position = new Vector3(this.transform.position.x + Random.Range(0, 1) * Time.deltaTime, this.transform.position.y + Random.Range(0, 1) * Time.deltaTime, this.transform.position.z);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator SpreadInRandomDirection()
    {

        Vector3 speed = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);

        while (this.gameObject != null)
        {
            this.gameObject.transform.position += speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    public void SetCorrect(bool b)
    {
        isCorrect = b;
    }

    public void StartFading()
    {
        this.GetComponent<Image>().canvasRenderer.SetAlpha(0.01f);
        fadeIn = true;
        timeToPass = 5f;
        lastTime = Time.realtimeSinceStartup;

        StartCoroutine(SpreadInRandomDirection());
        StartCoroutine(GrowBigger());
    }

    /*
    public void SetLerpManager(LerpManager l)
    {
        lerpManager = l;
        lerpManager.Rect = this.gameObject;
        lerpManager.LerpColorAlphaSimpleTwoWayCanvas(lerpDuration);
    }
    */

    public void SetMinigame(WordsAppearingMinigame w)
    {
        wordsAppearingMinigame = w;
    }

    public void SetText(string text)
    {
        this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        this.text = text;
    }

    public void Clicked()
    {
        if (!isCorrect)
        {
            wordsAppearingMinigame.WrongChoice();
            
        }
        else
        {
            wordsAppearingMinigame.RemoveTextOutOfInternal(this.text);
        }
        wordsAppearingMinigame.RemoveObjectOutOfInternal(this);
        Destroy(this.gameObject);
    }
}
