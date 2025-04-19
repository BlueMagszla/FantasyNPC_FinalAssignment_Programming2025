//ms 3

using NodeCanvas.Framework;
using ParadoxNotion.Serialization.FullSerializer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWorkAT : ActionTask
{
    public BBParameter<VillagerController> villagerController;
    public BBParameter<bool> isSleeping;
    //protected override void On
    protected override void OnExecute()
    {
        isSleeping = false;
        if (villagerController.value.Target == null || villagerController.value.Target.tag != "Work")
        {
            villagerController.value.Target = villagerController.value.Work.transform;
            EndAction(true);
        }
    }
}
