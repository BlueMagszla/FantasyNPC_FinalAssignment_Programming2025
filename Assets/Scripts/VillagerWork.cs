using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerWork : MonoBehaviour
{

    public bool isAssigned = false; 

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Work";
        GameManager.instance.villagerJobs.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public VillagerWork Assign()
    {
        isAssigned = true;
        return this;

    }
}
