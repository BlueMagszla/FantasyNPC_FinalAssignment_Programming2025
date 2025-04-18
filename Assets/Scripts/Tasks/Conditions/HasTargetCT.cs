//ms
using NodeCanvas.Framework;
using UnityEngine;

public class HasTargetCT : ConditionTask
{
   public BBParameter<ZombieController> zombieController;


    protected override bool OnCheck()
    {
        return zombieController.value.Target != null;
    }
}
