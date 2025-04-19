//ms
using NodeCanvas.Framework;
using UnityEngine;

public class HasVillageTargetCT : ConditionTask
{
   public BBParameter<ZombieController> zombieController;

    protected override bool OnCheck()
    {
        if (zombieController.value.Target != null)
        {
            return zombieController.value.Target.tag == "Village";
        }
        return false;
    }
}
