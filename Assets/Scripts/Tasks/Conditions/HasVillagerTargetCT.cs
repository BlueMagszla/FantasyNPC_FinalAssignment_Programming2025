using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasVillagerTargetCT : ConditionTask
{
    public BBParameter<ZombieController> zombieController;

    protected override bool OnCheck()
    {
        if (zombieController.value.Target != null)
        {
            return zombieController.value.Target.tag == "Villager";
        }
        return false;
    }
}
