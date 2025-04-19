//ms
using NodeCanvas.Framework;
using UnityEngine;

public class HasTargetCT : ConditionTask
{
   public BBParameter<ZombieController> zombieController;


    protected override bool OnCheck()
    {
        if (zombieController.value.Target != null)
        {
            return zombieController.value.Target.tag != "Shade";
        }
        return false;
    }
}
