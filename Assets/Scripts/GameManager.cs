//ms 1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public float cycleLength = 360f; //seconds in day or night
    public float time = 0f;
    public float transitionTime = 10f;

    public Material skyboxDay;
    public Material skyboxDusk;
    public Material skyboxNight;

    public static GameManager instance;

    public List<VillagerBed> villagerBeds;
    public List<VillagerWork> villagerJobs;

    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        RenderSettings.skybox = skyboxDay;

    }

    // Update is called once per frame
    void Update()
    {
        time = (time + Time.deltaTime) % cycleLength;

        if (time < cycleLength / 2 - transitionTime)
        {
            RenderSettings.skybox = skyboxDay;
        }

        else if (time > cycleLength / 2 && time < cycleLength - transitionTime)
        {
            RenderSettings.skybox = skyboxNight;
        }

        else
        {
            RenderSettings.skybox = skyboxDusk;
        }

    }

    public VillagerWork getRandomJob()
    {
        foreach (var job in villagerJobs) {
            if (!job.isAssigned)
            {
                return job;
            }
        }
        return null;
    }

    public VillagerBed getRandomBed()
    {
        foreach (var bed in villagerBeds)
        {
            if (!bed.isAssigned)
            {
                return bed;
            }
        }
        return null;
    }







}
