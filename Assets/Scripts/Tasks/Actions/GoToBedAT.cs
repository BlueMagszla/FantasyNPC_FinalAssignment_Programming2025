//ms 3

using NodeCanvas.Framework;
using ParadoxNotion.Serialization.FullSerializer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBedAT : ActionTask
{
    public BBParameter<VillagerController> villagerController;
    public BBParameter<bool> isWorking;
    //protected override void On
    protected override void OnExecute()
    {
        isWorking = false;
        if (villagerController.value.Target == null || villagerController.value.Target.tag != "Bed")
        {
            villagerController.value.Target = villagerController.value.Bed.transform;
            EndAction(true);
        }
    }
}
