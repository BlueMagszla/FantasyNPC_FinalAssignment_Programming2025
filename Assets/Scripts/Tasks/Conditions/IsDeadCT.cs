using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDeadCT : ConditionTask
{
    public BBParameter<ZombieController> zombieController;
    public BBParameter<VillagerController> villagerController;
    protected override bool OnCheck()
    {
        if (zombieController.value != null)
            return zombieController.value.health <= 0;
        if (villagerController.value != null)
            return villagerController.value.health <= 0;
        return true;
    }

}
