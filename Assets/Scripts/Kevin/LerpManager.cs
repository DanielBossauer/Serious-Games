using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using System.Linq;
using UnityEngine.UI;

public class LerpManager : MonoBehaviour
{
    [SerializeField]
    public GameObject Rect;
    [SerializeField]
    public GameObject SecondRect;
    [SerializeField]
    public Transform StartPoint;
    [SerializeField]
    private Transform CenterTarget;
    [SerializeField]
    public Transform EndPoint;
    [SerializeField]
    private TextMeshPro[] Texts;
    [SerializeField]
    private MinMaxCurve Curve;
    [SerializeField]
    [Range(0, 100)]
    private float LerpSpeed = 1f;
    [Range(0, 100)]
    [SerializeField]
    private float MoveSpeed = 2f;
    [SerializeField]
    bool deactivateGUI = true;

    private Coroutine LerpCoroutine;

    public void SetSpeeds(float lerpSpeed, float moveSpeed)
    {
        this.LerpSpeed = lerpSpeed;
        this.MoveSpeed = moveSpeed;
    }

    private void OnGUI()
    {
        if (!deactivateGUI)
        {
            if (GUI.Button(new Rect(10, 10, 225, 30), "Vector3 Lerp Fixed Time"))
            {
                if (LerpCoroutine != null)
                {
                    StopCoroutine(LerpCoroutine);
                }

                LerpCoroutine = StartCoroutine(LerpRectFixedTime());
            }
            if (GUI.Button(new Rect(10, 50, 225, 30), "Vector3 Lerp \"Fixed\" Speed"))
            {
                if (LerpCoroutine != null)
                {
                    StopCoroutine(LerpCoroutine);
                }

                LerpCoroutine = StartCoroutine(LerpRectFixedSpeed());
            }
            if (GUI.Button(new Rect(10, 90, 225, 30), "Quaternion Lerp/Slerp Fixed Time"))
            {
                if (LerpCoroutine != null)
                {
                    StopCoroutine(LerpCoroutine);
                }

                LerpCoroutine = StartCoroutine(LerpRotationFixedTime());
            }
            if (GUI.Button(new Rect(10, 130, 225, 30), "Lerp Color"))
            {
                if (LerpCoroutine != null)
                {
                    StopCoroutine(LerpCoroutine);
                }

                LerpCoroutine = StartCoroutine(LerpColor());
            }
            if (GUI.Button(new Rect(10, 170, 225, 30), "Vector3 Slerp"))
            {
                if (LerpCoroutine != null)
                {
                    StopCoroutine(LerpCoroutine);
                }

                LerpCoroutine = StartCoroutine(SlerpRectFixedTime());
            }
        }


        
    }

    private void DisableSecondaryAndTexts()
    {
        foreach (TextMeshPro text in Texts)
        {
            text.gameObject.SetActive(false);
        }
        if(SecondRect != null) SecondRect.gameObject.SetActive(false);
    }

    public IEnumerator LerpRectFixedTime()
    {
        DisableSecondaryAndTexts();
        Rect.transform.rotation = Quaternion.identity;

        while (true)
        {
            float time = 0;
            float random = Random.value;
            while (time < 1)
            {
                Rect.transform.position = Vector3.Lerp(
                    StartPoint.position, 
                    EndPoint.position, 
                    Curve.Evaluate(time, random)
                );
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }

            random = Random.value;
            while (time > 0)
            {
                Rect.transform.position = Vector3.Lerp(
                    StartPoint.position, 
                    EndPoint.position, 
                    Curve.Evaluate(time, random)
                );
                time -= Time.deltaTime * LerpSpeed;
                yield return null;
            }
        }
    }

    public IEnumerator LerpRectFixedTimeOneWay()
    {
        DisableSecondaryAndTexts();
        Rect.transform.rotation = Quaternion.identity;

        
        float time = 0;
        float random = Random.value;
        while (time < 1)
        {
                Rect.transform.position = Vector3.Lerp(
                    StartPoint.position,
                    EndPoint.position,
                    Curve.Evaluate(time, random)
                );
                time += Time.deltaTime * LerpSpeed;
                yield return null;
        }

           
        
    }

    private IEnumerator SlerpRectFixedTime()
    {
        DisableSecondaryAndTexts();
        Rect.transform.rotation = Quaternion.identity;

        while (true)
        {
            float time = 0;
            float random = Random.value;
            while (time < 1)
            {
                Rect.transform.position = Vector3.Slerp(
                    StartPoint.position, 
                    EndPoint.position, 
                    Curve.Evaluate(time, random)
                );
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }

            random = Random.value;
            while (time > 0)
            {
                Rect.transform.position = Vector3.Slerp(
                    StartPoint.position, 
                    EndPoint.position, 
                    Curve.Evaluate(time, random)
                );
                time -= Time.deltaTime * LerpSpeed;
                yield return null;
            }
        }
    }

    private IEnumerator LerpRectFixedSpeed()
    {
        DisableSecondaryAndTexts();
        Rect.transform.rotation = Quaternion.identity;

        while (true)
        {
            float distance = Vector3.Distance(
                StartPoint.position, 
                EndPoint.position
            );
            float remainingDistance = distance;
            float random = Random.value;
            while (remainingDistance > 0)
            {
                Rect.transform.position = Vector3.Lerp(
                    StartPoint.position, 
                    EndPoint.position, 
                    Curve.Evaluate(1 - (remainingDistance / distance), random)
                );
                remainingDistance -= MoveSpeed * Time.deltaTime;
                yield return null;
            }

            remainingDistance = distance;
            random = Random.value;
            while (remainingDistance > 0)
            {
                Rect.transform.position = Vector3.Lerp(
                    StartPoint.position, 
                    EndPoint.position, 
                    Curve.Evaluate(remainingDistance / distance, random)
                );
                remainingDistance -= MoveSpeed * Time.deltaTime;
                yield return null;
            }
        }
    }

    private IEnumerator LerpRotationFixedTime()
    {
        SecondRect.gameObject.SetActive(true);
        Rect.transform.rotation = Quaternion.identity;
        SecondRect.transform.rotation = Quaternion.identity;
        Rect.transform.position = StartPoint.position;
        SecondRect.transform.position = EndPoint.position;

        foreach (TextMeshPro text in Texts)
        {
            text.gameObject.SetActive(true);
        }

        while (true)
        {
            float time = 0;
            float random = Random.value;
            while (time < 1)
            {
                Rect.transform.rotation = Quaternion.Lerp(
                    Quaternion.identity, 
                    Quaternion.Euler(0, 180, 0), 
                    Curve.Evaluate(time, random)
                );
                SecondRect.transform.rotation = Quaternion.Slerp(
                    Quaternion.identity, 
                    Quaternion.Euler(0, 180, 0), 
                    Curve.Evaluate(time, random)
                );
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }

            time = 0;
            random = Random.value;
            while (time < 1)
            {
                Rect.transform.rotation = Quaternion.Lerp(
                    Quaternion.Euler(0, 180, 0), 
                    Quaternion.Euler(0, 360, 0), 
                    Curve.Evaluate(time, random)
                );
                SecondRect.transform.rotation = Quaternion.Slerp(
                    Quaternion.Euler(0, 180, 0), 
                    Quaternion.Euler(0, 360, 0), 
                    Curve.Evaluate(time, random)
                );
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }
        }
    }

    public IEnumerator LerpRectAndRotationFixedTimeOneWay()
    {



        DisableSecondaryAndTexts();



        Rect.transform.rotation = StartPoint.rotation;

        Rect.transform.position = StartPoint.position;
        

        foreach (TextMeshPro text in Texts)
        {
            text.gameObject.SetActive(true);
        }

        
        float time = 0;
        float random = Random.value;
            while (time < 1)
            {

                Rect.transform.position = Vector3.Lerp(
                StartPoint.position,
                EndPoint.position,
                Curve.Evaluate(time, random)
                );


                Rect.transform.rotation = Quaternion.Lerp(
                    StartPoint.rotation,
                    EndPoint.rotation,
                    Curve.Evaluate(time, random)
                );
                
                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }

        time = 0;
        random = Random.value;
        
    }

    public IEnumerator LerpRotationFixedTimeOneWay()
    {
        SecondRect.gameObject.SetActive(true);
        Rect.transform.rotation = Quaternion.identity;
        SecondRect.transform.rotation = Quaternion.identity;
        Rect.transform.position = StartPoint.position;
        SecondRect.transform.position = EndPoint.position;

        foreach (TextMeshPro text in Texts)
        {
            text.gameObject.SetActive(true);
        }


        float time = 0;
        float random = Random.value;
        while (time < 1)
        {
            Rect.transform.rotation = Quaternion.Lerp(
                Quaternion.identity,
                Quaternion.Euler(0, 180, 0),
                Curve.Evaluate(time, random)
            );
            SecondRect.transform.rotation = Quaternion.Slerp(
                Quaternion.identity,
                Quaternion.Euler(0, 180, 0),
                Curve.Evaluate(time, random)
            );
            time += Time.deltaTime * LerpSpeed;
            yield return null;
        }

        time = 0;
        random = Random.value;
    }

    
    private IEnumerator LerpColor()
    {
        DisableSecondaryAndTexts();
        Rect.transform.position = CenterTarget.position;
        Rect.transform.rotation = Quaternion.identity;

        Mesh mesh = Rect.GetComponent<MeshFilter>().mesh;

        Color[] startColors = new Color[mesh.colors.Length];
        Color[] targetColors = new Color[mesh.colors.Length];
        List<Color> currentColors = new List<Color>();
        for (int i = 0; i < mesh.colors.Length; i++)
        {
            startColors[i] = mesh.colors[i];
            targetColors[i] = Color.black;
        }

        while (true)
        {
            currentColors.Clear();
            mesh.GetColors(currentColors);
            float time = 0;
            float random = Random.value;
            while (time < 1)
            {
                for (int i = 0; i < currentColors.Count; i++)
                {
                    currentColors[i] = Color.Lerp(
                        startColors[i], 
                        targetColors[i], 
                        Curve.Evaluate(time, random)
                    );
                }

                mesh.SetColors(currentColors);

                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }

            time = 1;
            random = Random.value;
            while (time > 0)
            {
                for (int i = 0; i < currentColors.Count; i++)
                {
                    currentColors[i] = Color.Lerp(
                        startColors[i],
                        targetColors[i],
                        Curve.Evaluate(time, random)
                    );
                }

                mesh.SetColors(currentColors);

                time -= Time.deltaTime * LerpSpeed;
                yield return null;
            }
        }
    }

    public Color firstColor;
    public Color secondColor;

    /*
    public IEnumerator LerpColorSimpleTwoWay()
    {
        DisableSecondaryAndTexts();
        

        Mesh mesh = Rect.GetComponent<MeshFilter>().mesh;

        Color[] startColors = new Color[mesh.colors.Length];
        Color[] targetColors = new Color[mesh.colors.Length];
        List<Color> currentColors = new List<Color>();
        for (int i = 0; i < mesh.colors.Length; i++)
        {
            startColors[i] = mesh.colors[i];
            targetColors[i] = Color.black;
        }

        
            currentColors.Clear();
            mesh.GetColors(currentColors);
            float time = 0;
            float random = Random.value;
            while (time < 1)
            {
                for (int i = 0; i < currentColors.Count; i++)
                {
                    currentColors[i] = Color.Lerp(
                        startColors[i],
                        targetColors[i],
                        Curve.Evaluate(time, random)
                    );
                }

                mesh.SetColors(currentColors);

                time += Time.deltaTime * LerpSpeed;
                yield return null;
            }

            time = 1;
            random = Random.value;
            while (time > 0)
            {
                for (int i = 0; i < currentColors.Count; i++)
                {
                    currentColors[i] = Color.Lerp(
                        startColors[i],
                        targetColors[i],
                        Curve.Evaluate(time, random)
                    );
                }

                mesh.SetColors(currentColors);

                time -= Time.deltaTime * LerpSpeed;
                yield return null;
            }
        
    }*/

    public void CALLLerpColorAlphaSimpleTwoWay()
    {
        StartCoroutine(LerpColorAlphaSimpleTwoWay());
    }

    public IEnumerator LerpColorAlphaSimpleTwoWayCanvas(float duration)
    {
        this.Rect.GetComponent<Image>().canvasRenderer.SetAlpha(0.01f);
        
        this.Rect.GetComponent<Image>().CrossFadeAlpha(1f, duration, false);

        yield return new WaitForEndOfFrame();
        
        yield return null;
    }

    public IEnumerator LerpColorAlphaSimpleTwoWay()
    {
        DisableSecondaryAndTexts();


        Mesh mesh = Rect.GetComponent<MeshFilter>().mesh;

        Color[] startColors = new Color[mesh.colors.Length];
        Color[] targetColors = new Color[mesh.colors.Length];
        List<Color> currentColors = new List<Color>();
        for (int i = 0; i < mesh.colors.Length; i++)
        {
            startColors[i] = mesh.colors[i];
            targetColors[i] = mesh.colors[i];

            startColors[i] = new Color(startColors[i].r, startColors[i].g, startColors[i].b,0f);
        }


        currentColors.Clear();
        mesh.GetColors(currentColors);



        float time = 0;
        float random = Random.value;
        while (time < 1)
        {
            for (int i = 0; i < currentColors.Count; i++)
            {
                currentColors[i] = Color.Lerp(
                    startColors[i],
                    targetColors[i],
                    Curve.Evaluate(time, random)
                );
            }

            mesh.SetColors(currentColors);

            time += Time.deltaTime * LerpSpeed;
            yield return null;
        }

        time = 1;
        random = Random.value;
        while (time > 0)
        {
            for (int i = 0; i < currentColors.Count; i++)
            {
                currentColors[i] = Color.Lerp(
                    startColors[i],
                    targetColors[i],
                    Curve.Evaluate(time, random)
                );
            }

            mesh.SetColors(currentColors);

            time -= Time.deltaTime * LerpSpeed;
            yield return null;
        }
    }

    public void CALLFadeInOneWay()
    {
        //StartCoroutine(FadeInOneWay());
    }

    /*
    public IEnumerator FadeInOneWayCanvas()
    {
        DisableSecondaryAndTexts();


        //Mesh mesh = Rect.GetComponent<MeshFilter>().mesh;

        Material[] materials = CanvasRendererGetMaterials();

        /*
        Color[] startColors = new Color[mesh.colors.Length];
        Color[] targetColors = new Color[mesh.colors.Length];
        List<Color> currentColors = new List<Color>();
        for (int i = 0; i < mesh.colors.Length; i++)
        {
            startColors[i] = new Color(mesh.colors[i].r, mesh.colors[i].g, mesh.colors[i].b, 0f);
            targetColors[i] = mesh.colors[i];
        }
        */
    /*
    Color[] startColors = new Color[materials.Length];
    Color[] targetColors = new Color[materials.Length];
    List<Color> currentColors = new List<Color>();
    for (int i = 0; i < materials.Length; i++)
    {
        startColors[i] = new Color(materials[i].color.r, materials[i].color.g, materials[i].color.b, 0f);
        targetColors[i] = materials[i].color;
    }


    currentColors.Clear();
    //mesh.GetColors(currentColors);
    currentColors = CanvasRendererGetColors();
    float time = 0;
    float random = Random.value;
    while (time < 1)
    {
            for (int i = 0; i < currentColors.Count; i++)
            {
                currentColors[i] = Color.Lerp(
                    startColors[i],
                    targetColors[i],
                    Curve.Evaluate(time, random)
                );
            }

        //mesh.SetColors(currentColors);
        CanvasRendererSetColors(currentColors);

        time += Time.deltaTime * LerpSpeed;
        yield return null;
    }
}
*/
    public void FadeInOneWayCanvas(bool updateFadeHasText, float fadeDuration)
    {
        //TODO: add the canvas fade in function
        //Rect.SetActive(true);
        //yield return null;

        Rect.GetComponent<Image>().canvasRenderer.SetAlpha(0.01f);
        if (updateFadeHasText) Rect.transform.GetChild(0).GetComponent<TextMeshProUGUI>().canvasRenderer.SetAlpha(0.01f);
        Rect.SetActive(true);

        timeToPass = 5f;
        lastTime = Time.realtimeSinceStartup;

        updateFadeOut = false;
        updateFadeIn = true;

        this.updateFadeHasText = updateFadeHasText;
        this.fadeDuration = fadeDuration;
    }

    public void FadeOutOneWayCanvas(bool updateFadeHasText, float fadeDuration)
    {
        //TODO: add the canvas fade out function
        //Rect.SetActive(false);
        //yield return null;

        Rect.GetComponent<Image>().canvasRenderer.SetAlpha(0.99f);
        if (updateFadeHasText) Rect.transform.GetChild(0).GetComponent<TextMeshProUGUI>().canvasRenderer.SetAlpha(0.99f);
        Rect.SetActive(true);

        timeToPass = 5f;
        lastTime = Time.realtimeSinceStartup;

        updateFadeOut = true;
        updateFadeIn = false;

        this.updateFadeHasText = updateFadeHasText;
        this.fadeDuration = fadeDuration;
    }

    bool updateFadeOut;
    bool updateFadeIn;
    bool updateFadeHasText;
    float fadeDuration;

    float lastTime;
    float timeToPass;

    private void Update()
    {
        if (updateFadeIn)
        {
            //this.Rect.GetComponent<Image>().canvasRenderer.SetAlpha(0.01f);
            Rect.GetComponent<Image>().CrossFadeAlpha(1f, fadeDuration, false);
            if(updateFadeHasText) Rect.transform.GetChild(0).GetComponent<TextMeshProUGUI>().CrossFadeAlpha(1f, fadeDuration, false);
            if (Time.realtimeSinceStartup > lastTime + timeToPass)
            {
                lastTime = Time.realtimeSinceStartup;
                updateFadeIn = false;
                updateFadeOut = false;
                //updateFadeOut = true;
            }
        }

        if (updateFadeOut)
        {
            Rect.GetComponent<Image>().CrossFadeAlpha(0f, fadeDuration, false);
            if (updateFadeHasText) Rect.transform.GetChild(0).GetComponent<TextMeshProUGUI>().CrossFadeAlpha(0f, fadeDuration, false);
            if (Time.realtimeSinceStartup > lastTime + timeToPass)
            {
                lastTime = Time.realtimeSinceStartup;
                updateFadeIn = false;
                updateFadeOut = false;
                //wordsAppearingMinigame.RemoveObjectOutOfInternal(this);
                //Destroy(this.gameObject);
            }
        }
    }

    Material[] CanvasRendererGetMaterials()
    {
        Material[] materials = new Material[Rect.GetComponent<CanvasRenderer>().materialCount];
        CanvasRenderer canvasRenderer = Rect.GetComponent<CanvasRenderer>();
        for (int i = 0; i < canvasRenderer.materialCount; i++)
        {
            materials[i] = canvasRenderer.GetMaterial(i);
        }
        return materials;
    }

    List<Color> CanvasRendererGetColors()
    {
        Material[] tmp = CanvasRendererGetMaterials();
        Color[] colors = new Color[tmp.Length];
        for(int i=0;i<tmp.Length;i++)
        {
            colors[i] = tmp[i].color;
        }
        return colors.ToList();
    }

    void CanvasRendererSetColors(List<Color> currentColors)
    {
        Material[] tmp = CanvasRendererGetMaterials();
        for (int i = 0; i < currentColors.Count; i++)
        {
            tmp[i].color = currentColors[i];
        }
        for (int i=0; i<tmp.Length;i++)
        {
            Rect.GetComponent<CanvasRenderer>().SetMaterial(tmp[0],i);
        }
        
    }


    public IEnumerator FadeOutOneWay()
    {
        DisableSecondaryAndTexts();
        //Rect.transform.position = CenterTarget.position;
        //Rect.transform.rotation = Quaternion.identity;

        Mesh mesh = Rect.GetComponent<MeshFilter>().mesh;

        Color[] startColors = new Color[mesh.colors.Length];
        Color[] targetColors = new Color[mesh.colors.Length];
        List<Color> currentColors = new List<Color>();
        for (int i = 0; i < mesh.colors.Length; i++)
        {
            startColors[i] = mesh.colors[i];
            targetColors[i] = new Color(mesh.colors[i].r, mesh.colors[i].g, mesh.colors[i].b, 0f);
        }


        currentColors.Clear();
        mesh.GetColors(currentColors);
        float time = 0;
        float random = Random.value;
        while (time < 1)
        {
            for (int i = 0; i < currentColors.Count; i++)
            {
                currentColors[i] = Color.Lerp(
                    startColors[i],
                    targetColors[i],
                    Curve.Evaluate(time, random)
                );
            }

            mesh.SetColors(currentColors);

            time += Time.deltaTime * LerpSpeed;
            yield return null;
        }



    }

    public void SetActiveFalse()
    {
        Rect.gameObject.SetActive(false);
    }

    public void SetActiveTrue()
    {
        Rect.gameObject.SetActive(true);
    }

    public void StopAllLerps()
    {
        StopAllCoroutines();
    }
}
