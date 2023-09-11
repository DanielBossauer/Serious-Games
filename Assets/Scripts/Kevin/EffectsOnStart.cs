using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EffectsOnStart : MonoBehaviour
{

    [SerializeField] Volume m_Volume;

    [SerializeField] float startFilmGrainIntensity = 0.9f;
    [SerializeField] float startIntensityVignette = 0.417f;
    [SerializeField] float startSmoothnessVignette = 0.733f;
    [SerializeField] int startFilmGrainType = 1;
    [SerializeField] int colorAdjustmentsContrast = 0;

    [SerializeField] LerpManager lerpManager;
    [SerializeField] float lerpSpeed = 1f;
    [SerializeField] float moveSpeed = 2f;

    [SerializeField] float bloomThreshold;
    [SerializeField] Color bloomColor;
    [SerializeField] float bloomIntensity;

    [SerializeField] bool changeBloom;
    [SerializeField] VisualEffectsChanger visualEffectsChanger;

    // Start is called before the first frame update
    public void Start()
    {
        VolumeProfile profile = m_Volume.sharedProfile;
        if (!profile.TryGet<FilmGrain>(out var grain))
        {
            grain = profile.Add<FilmGrain>(false);
        }

        grain.intensity.Override(startFilmGrainIntensity);
        grain.type = new FilmGrainLookupParameter((FilmGrainLookup)startFilmGrainType, true);



        if (!profile.TryGet<Vignette>(out var vignette))
        {
            vignette = profile.Add<Vignette>(false);
        }

        vignette.intensity.Override(startIntensityVignette);
        vignette.smoothness.Override(startSmoothnessVignette);



        if (!profile.TryGet<ColorAdjustments>(out var colorAdjustments))
        {
            colorAdjustments = profile.Add<ColorAdjustments>(false);
        }

        colorAdjustments.contrast.Override(colorAdjustmentsContrast);



        if (changeBloom)
        {
            visualEffectsChanger.ChangeBloomThreshold(bloomThreshold);
            visualEffectsChanger.ChangeBloomColor(bloomColor);
            visualEffectsChanger.ChangeBloomIntensity(bloomIntensity);

            //bloom.Release();
        }




        if (lerpManager!=null) lerpManager.SetSpeeds(lerpSpeed, moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
