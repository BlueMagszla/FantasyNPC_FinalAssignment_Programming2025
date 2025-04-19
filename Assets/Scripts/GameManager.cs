//ms 1

using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
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

    public NavMeshModifierVolume villageArea;
    public NavMeshModifierVolume shadeArea;



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

    public Transform getVillageTarget() //get random spot in the village area
    {
        //get random spot
        Vector3 coords = new Vector3(Random.Range(villageArea.gameObject.transform.position.x - villageArea.size.x / 2, villageArea.gameObject.transform.position.x + villageArea.size.x / 2),
                                     villageArea.center.y,
                                     Random.Range(villageArea.gameObject.transform.position.z - villageArea.size.z / 2, villageArea.gameObject.transform.position.z + villageArea.size.z / 2));

        GameObject target = new GameObject("VillageTarget"); //spawn empty on coordinates
        target.transform.position = coords;
        target.tag = "Village";
        Destroy(target, cycleLength / 2f); //destroy after night passes

        return target.transform;  //returning spot transform
    }
    static float test = 0;
    public Transform getShadeTarget() //get random spot in the shade area
    {
        test++;
        //get random spot
        Vector3 coords = new Vector3(Random.Range(shadeArea.gameObject.transform.position.x - shadeArea.size.x / 2, shadeArea.gameObject.transform.position.x + shadeArea.size.x / 2),
        shadeArea.center.y,
        Random.Range(shadeArea.gameObject.transform.position.z - shadeArea.size.z / 2, shadeArea.gameObject.transform.position.z + shadeArea.size.z / 2));

        GameObject target = new GameObject("ShadeTarget"); //spawn empty on coordinates
        target.tag = "Shade";
        target.transform.position = coords;
        Destroy(target, cycleLength / 2f); //destroy after day passes
        return target.transform;  //returning spot transform
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
