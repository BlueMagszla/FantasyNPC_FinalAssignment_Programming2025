/* Has Target Condition Task
 * 
 * Script handles if the zombie has a target
 * 
 * Magdalena Szlapczynski
 * Last Modified: Apr.19, 2025
 */
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
