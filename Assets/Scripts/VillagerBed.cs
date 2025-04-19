using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerBed : MonoBehaviour
{

    public bool isAssigned = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Bed";
        GameManager.instance.villagerBeds.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public VillagerBed Assign()
    {
        isAssigned = true;
        return this;

    }
}
