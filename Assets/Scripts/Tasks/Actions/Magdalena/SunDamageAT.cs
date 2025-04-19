//ms

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

public class SunDamageAT : ActionTask
{
    public BBParameter<ZombieController> zombieController;

    public float elapsedTimeS = 0; //to not take damage each frame the zombie is in sunlight
    public int sunDamage = 2; //damage zombie will recieve

    protected override void OnUpdate()
    {
        elapsedTimeS += Time.deltaTime;    

        if (elapsedTimeS > 1)
        {
            zombieController.value.health -= sunDamage;
            elapsedTimeS = 0;
        }
    }

    protected override void OnExecute()
    {
       // elapsedTimeS = 0; //reset buildup after being in shade
    }
}
