using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDeadCT : ConditionTask
{
    public BBParameter<ZombieController> zombieController;
    protected override bool OnCheck()
    {
        return zombieController.value.health < 0;
    }

}
