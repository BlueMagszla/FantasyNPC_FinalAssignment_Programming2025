using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasBedTargetCT : ConditionTask
{
    public BBParameter<VillagerController> villagerController;

    protected override bool OnCheck()
    {
        if (villagerController.value.Target != null)
        {
            return villagerController.value.Target.tag == "Bed";
        }
        return false;
    }
}
