//ms 3

using NodeCanvas.Framework;
using ParadoxNotion.Serialization.FullSerializer;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkAT : ActionTask
{
    public BBParameter<VillagerController> villagerController;
    public BBParameter<bool> isWorking;
    //protected override void On
    protected override void OnExecute()
    {
        if (isWorking.value == true)
        {
            return;
        }
        if (Vector3.Distance(villagerController.value.transform.position, villagerController.value.Bed.transform.position) < 0.1)
        {
            //villagerController.value Snap to bed
            isWorking = true;
        }
    }
}
