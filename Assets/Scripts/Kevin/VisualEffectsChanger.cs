using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class VisualEffectsChanger : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Volume m_Volume;
    [SerializeField] Light[] suns;

    SUPERCharacterAIO superCharacter;

    // Start is called before the first frame update
    void Start()
    {
        superCharacter = player.gameObject.GetComponent<SUPERCharacterAIO>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void ChangeBloom(float intensity, Color color, float threshold)
    {
        VolumeProfile profile = m_Volume.sharedProfile;
        if (!profile.TryGet<Bloom>(out var bloom))
        {
            bloom = profile.Add<Bloom>(false);
        }

        bloom.intensity.Override(intensity);
        bloom.tint.Override(color);
        bloom.threshold.Override(threshold);
    }

    public void ChangeFilmGrain(string grainIntensity)
    {
        //GRAIN
        VolumeProfile profile = m_Volume.sharedProfile;
        if (!profile.TryGet<FilmGrain>(out var grain))
        {
            grain = profile.Add<FilmGrain>(false);
        }

        var sStrings = grainIntensity.Split(","[0]);
        float x = float.Parse(sStrings[0]); 

        grain.intensity.Override(x);
    }

    public void MakeRed()
    {
        if (suns != null && suns[0] != null)
        {
            foreach (Light sun in suns)
            {
                if (sun != null) sun.color = new Color(sun.color.r, 0f, 0f);
            }

        }
    }


    public void ChangeVisuals2(float grainIntensity, float vignetteIntensity, float vignetteSmoothness, int filmGrainType, int colorAdjustmentsContrast)
    {
        VolumeProfile profile = m_Volume.sharedProfile;
        if (!profile.TryGet<FilmGrain>(out var grain))
        {
            grain = profile.Add<FilmGrain>(false);
        }

        grain.intensity.Override(grainIntensity);
        grain.type = new FilmGrainLookupParameter((FilmGrainLookup)filmGrainType, true);



        if (!profile.TryGet<Vignette>(out var vignette))
        {
            vignette = profile.Add<Vignette>(false);
        }

        vignette.intensity.Override(vignetteIntensity);
        vignette.smoothness.Override(vignetteSmoothness);



        if (!profile.TryGet<ColorAdjustments>(out var colorAdjustments))
        {
            colorAdjustments = profile.Add<ColorAdjustments>(false);
        }

        colorAdjustments.contrast.Override(colorAdjustmentsContrast);
    }


    public void ChangeVisuals(float grainIntensity, float vignetteIntensity, float vignetteSmoothness, float sunRedness)
    {
        //GRAIN
        VolumeProfile profile = m_Volume.sharedProfile;
        if (!profile.TryGet<FilmGrain>(out var grain))
        {
            grain = profile.Add<FilmGrain>(false);
        }

        grain.intensity.Override(grainIntensity);



        //VIGNETTE
        if (!profile.TryGet<Vignette>(out var vignette))
        {
            vignette = profile.Add<Vignette>(false);
        }

        vignette.intensity.Override(vignetteIntensity);
        vignette.smoothness.Override(vignetteSmoothness);


        //LIGHTS AND SUNS

        if (suns != null && suns[0] != null)
        {
            foreach (Light sun in suns)
            {
                if (sun != null) sun.color = new Color(sun.color.r, sunRedness, sunRedness);
            }

        }



        //superCharacter.walkingSpeed = initialWalkingSpeed * distance / 15;
        //superCharacter.rotationWeight = initialRoationWeight * distance / 15;


        //superCharacter.walkingSpeed = initialWalkingSpeed;
        //superCharacter.rotationWeight = initialRoationWeight;




        //Application.targetFrameRate = ((int)(60 * (distance / 10f)) - 10);


        //Application.targetFrameRate = 60;






        //superCharacter.enableCameraControl = false;
        //superCharacter.enableMovementControl = false;
        //superCharacter.rotationWeight = 25f;
    }



    public void ChangeVisualsNervous0()
    {


        StopAllCoroutines();
        StartCoroutine(SlightlyNervous0());


        



        


        //LIGHTS AND SUNS

        /*
        if (suns != null && suns[0] != null)
        {
            foreach (Light sun in suns)
            {
                if (sun != null) sun.color = new Color(sun.color.r, 0, 0);
            }

        }
        */



        //superCharacter.walkingSpeed = initialWalkingSpeed * distance / 15;
        //superCharacter.rotationWeight = initialRoationWeight * distance / 15;


        //superCharacter.walkingSpeed = initialWalkingSpeed;
        //superCharacter.rotationWeight = initialRoationWeight;




        //Application.targetFrameRate = ((int)(60 * (distance / 10f)) - 10);


        //Application.targetFrameRate = 60;






        //superCharacter.enableCameraControl = false;
        //superCharacter.enableMovementControl = false;
        //superCharacter.rotationWeight = 25f;
    }



    public void SadAndLonely()
    {
        StopAllCoroutines();
        StartCoroutine(Lonely());
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Application.LoadLevel(Application.loadedLevel);
    }


    public void CALLVeryNervous0()
    {
        StopAllCoroutines();
        StartCoroutine(VeryNervous0());
    }



    IEnumerator VeryNervous0()
    {
        bool increaseVignette = true;
        bool increaseGrain = true;

        while (true)
        {
            //GRAIN
            VolumeProfile profile = m_Volume.sharedProfile;
            if (!profile.TryGet<FilmGrain>(out var grain))
            {
                grain = profile.Add<FilmGrain>(false);
            }





            //VIGNETTE
            if (!profile.TryGet<Vignette>(out var vignette))
            {
                vignette = profile.Add<Vignette>(false);
            }


            //COLORADJUSTMENTS

            if (!profile.TryGet<ColorAdjustments>(out var colorAdjustments))
            {
                colorAdjustments = profile.Add<ColorAdjustments>(false);
            }



            float speed = 2f;

            if (increaseVignette)
            {
                if (vignette.intensity.GetValue<float>() < 0.52) vignette.intensity.Override(Mathf.Clamp01(vignette.intensity.GetValue<float>() + speed * Time.deltaTime));
                else increaseVignette = false;

                //if (grain.intensity.GetValue<float>() < 0.8) grain.intensity.Override(Mathf.Clamp01(grain.intensity.GetValue<float>() - speed * Time.deltaTime));

                if (colorAdjustments.contrast.GetValue<float>() < 20) colorAdjustments.contrast.Override(colorAdjustments.contrast.GetValue<float>() + speed * Time.deltaTime);

            }
            else
            {
                if (vignette.intensity.GetValue<float>() > 0.5) vignette.intensity.Override(Mathf.Clamp01(vignette.intensity.GetValue<float>() - speed * Time.deltaTime));
                else increaseVignette = true;

                //if (grain.intensity.GetValue<float>() > 0.5) grain.intensity.Override(Mathf.Clamp01(grain.intensity.GetValue<float>() - speed * Time.deltaTime));

            }

            if (increaseGrain)
            {
                if (grain.intensity.GetValue<float>() < 0.8) grain.intensity.Override(Mathf.Clamp01(grain.intensity.GetValue<float>() + speed * Time.deltaTime));
                else increaseGrain = false;
            }
            else
            {
                if (grain.intensity.GetValue<float>() > 0.5) grain.intensity.Override(Mathf.Clamp01(grain.intensity.GetValue<float>() - speed * Time.deltaTime));
                else increaseGrain = true;
            }





            vignette.smoothness.Override(1f);

            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }


    IEnumerator SlightlyNervous0()
    {

        bool increaseVignette = true;
        bool increaseGrain = true;

        while (true)
        {
            //GRAIN
            VolumeProfile profile = m_Volume.sharedProfile;
            if (!profile.TryGet<FilmGrain>(out var grain))
            {
                grain = profile.Add<FilmGrain>(false);
            }

            



            //VIGNETTE
            if (!profile.TryGet<Vignette>(out var vignette))
            {
                vignette = profile.Add<Vignette>(false);
            }


            //COLORADJUSTMENTS

            if (!profile.TryGet<ColorAdjustments>(out var colorAdjustments))
            {
                colorAdjustments = profile.Add<ColorAdjustments>(false);
            }



            float speed = 2f;

            if (increaseVignette)
            {
                if (vignette.intensity.GetValue<float>() < 0.52) vignette.intensity.Override(Mathf.Clamp01(vignette.intensity.GetValue<float>() + speed * Time.deltaTime));
                else increaseVignette = false;

                //if (grain.intensity.GetValue<float>() < 0.8) grain.intensity.Override(Mathf.Clamp01(grain.intensity.GetValue<float>() - speed * Time.deltaTime));

                if (colorAdjustments.contrast.GetValue<float>() < 20) colorAdjustments.contrast.Override(colorAdjustments.contrast.GetValue<float>() + speed * Time.deltaTime);

            }
            else
            {
                if (vignette.intensity.GetValue<float>() > 0.5) vignette.intensity.Override(Mathf.Clamp01(vignette.intensity.GetValue<float>() - speed * Time.deltaTime));
                else increaseVignette = true;

                //if (grain.intensity.GetValue<float>() > 0.5) grain.intensity.Override(Mathf.Clamp01(grain.intensity.GetValue<float>() - speed * Time.deltaTime));
                
            }

            if (increaseGrain)
            {
                if (grain.intensity.GetValue<float>() < 0.8) grain.intensity.Override(Mathf.Clamp01(grain.intensity.GetValue<float>() - speed * Time.deltaTime));
                else increaseGrain = false;
            }
            else
            {
                if (grain.intensity.GetValue<float>() > 0.5) grain.intensity.Override(Mathf.Clamp01(grain.intensity.GetValue<float>() - speed * Time.deltaTime));
                else increaseGrain = true;
            }





            vignette.smoothness.Override(1f);

            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }



    IEnumerator Lonely()
    {
        yield return new WaitForEndOfFrame();
    }


    public void HouseNightTime()
    {
        StopAllCoroutines();
        ChangeVisuals2(1f,0.7f, 0.733f, 9,1);
    }

    public void HouseDayTime()
    {
        StopAllCoroutines();
        ChangeVisuals2(0.9f,0.417f,0.733f,1,70);
    }
}
