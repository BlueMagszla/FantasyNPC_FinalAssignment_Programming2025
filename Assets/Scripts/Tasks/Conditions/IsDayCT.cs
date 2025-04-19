using NodeCanvas.Framework;
using UnityEngine;

public class IsDayCT : ConditionTask
{

    protected override bool OnCheck()
    {
        return GameManager.instance.time < GameManager.instance.cycleLength / 2;
    }
}