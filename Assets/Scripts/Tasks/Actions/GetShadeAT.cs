//ms 3

using NodeCanvas.Framework;
using ParadoxNotion.Serialization.FullSerializer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShadeAT : ActionTask
{
    public BBParameter<ZombieController> zombieController;
    //protected override void On
    protected override void OnExecute()
    {
        if (zombieController.value.Target == null || zombieController.value.Target.tag != "Shade")
        {
            zombieController.value.Target = GameManager.instance.getShadeTarget(); //get village spot
            EndAction(true);
        }
    }
}
