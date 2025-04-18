using NodeCanvas.Framework;
using UnityEngine;

public class IsDayCT : ConditionTask
{
    public BBParameter<ZombieController> zombieController;
    //public BBParameter<VillagerController> villagerController;

    protected override bool OnCheck()
    {
        return GameManager.instance.time < GameManager.instance.cycleLength / 2;
    }
}