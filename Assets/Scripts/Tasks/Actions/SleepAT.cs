//ms 3

using NodeCanvas.Framework;
using ParadoxNotion.Serialization.FullSerializer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAT : ActionTask
{
    public BBParameter<VillagerController> villagerController;
    public BBParameter<bool> isSleeping;
    //protected override void On
    protected override void OnExecute()
    {
        if (isSleeping.value == true)
        {
            return;
        }
        if (Vector3.Distance(villagerController.value.transform.position, villagerController.value.Bed.transform.position) < 0.1)
        {
            //villagerController.value Snap to bed
            isSleeping = true;
        }
    }
}
