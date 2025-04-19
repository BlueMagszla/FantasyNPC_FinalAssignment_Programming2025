/* Has Village Target Condition Task
 * 
 * Script checks if target is the village.
 * 
 * Magdalena Szlapczynski
 *  Last Modified: Apr.19, 2025
 */
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
