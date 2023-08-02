using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChurchFilmGrainIncrease : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject player;
    [SerializeField] Volume m_Volume;
    //FilmGrain _postProcessingFilmGrain;
    [SerializeField] Light[] suns;

    [SerializeField] float someEmpiricConstant = 0.05f; //the higher the less is the effect

    SUPERCharacterAIO superCharacter;
    float initialWalkingSpeed;
    float initialRoationWeight;

    // Start is called before the first frame update
    void Start()
    {
        superCharacter = player.gameObject.GetComponent<SUPERCharacterAIO>();
        initialWalkingSpeed = superCharacter.walkingSpeed;
        initialRoationWeight = superCharacter.rotationWeight;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = 999f;
        GameObject chosenEnemy;

        //GET THE CLOSEST ENEMY TO THE PLAYER
        foreach(GameObject enemy in enemies)
        {
            float tempDistance = Vector3.Distance(enemy.transform.position, player.transform.position);
            if(tempDistance < distance)
            {
                distance = tempDistance;
                //chosenEnemy = enemy;
            }
        }
        


        VolumeProfile profile = m_Volume.sharedProfile;
        if (!profile.TryGet<FilmGrain>(out var grain))
        {
            grain = profile.Add<FilmGrain>(false);
        }

        grain.intensity.Override(Mathf.Clamp01(1 - distance * someEmpiricConstant));




        if (!profile.TryGet<Vignette>(out var vignette))
        {
            vignette = profile.Add<Vignette>(false);
        }

        vignette.intensity.Override(Mathf.Clamp01(1 - distance * someEmpiricConstant));
        vignette.smoothness.Override(Mathf.Clamp01(1 - distance * someEmpiricConstant));





        //if (!profile.TryGet<Bloom>(out var bloom))
        //{
        //    bloom = profile.Add<Bloom>(false);
        //}

        if (suns != null && suns[0] != null)
        {
            foreach (Light sun in suns)
            {
                if(sun!=null) sun.color = new Color(sun.color.r, Mathf.Clamp01(distance * someEmpiricConstant), Mathf.Clamp01(distance * someEmpiricConstant));
            }
      
        } 

        //bloom.intensity.Override(Mathf.Clamp01(1 - distance * someEmpiricConstant));
        //bloom.tint = new ColorParameter(new Color(1 - distance * someEmpiricConstant,
        //bloom.tint.value.b, bloom.tint.value.g));

        //VolumeProfile profile = m_Volume.sharedProfile;
        //_postProcessingFilmGrain = m_Volume.GetComponent<FilmGrain>();

        //_postProcessingFilmGrain.intensity.Override(distance * someEmpiricConstant);


        if(distance < 15f && distance >= 3f)
        {
            superCharacter.walkingSpeed = initialWalkingSpeed * distance/15;
            superCharacter.rotationWeight = initialRoationWeight * distance / 15;
        }
        else if(distance >= 15f)
        {
            superCharacter.walkingSpeed = initialWalkingSpeed;
            superCharacter.rotationWeight = initialRoationWeight;
        }


        if (distance < 10f)
        {
            Application.targetFrameRate = ((int)(60 * (distance/10f)) - 10) ;
        }
        else if(distance >= 10f)
        {
            Application.targetFrameRate = 60;
        }



        if(distance < 3f)
        {
            
            superCharacter.enableCameraControl = false;
            superCharacter.enableMovementControl = false;
            superCharacter.rotationWeight = 25f;
        }

    }
}
