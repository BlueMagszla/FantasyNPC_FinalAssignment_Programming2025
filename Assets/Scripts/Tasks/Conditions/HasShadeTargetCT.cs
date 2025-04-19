/* Has Shade Target CT
 * 
 * Script checks for shade tag.
 * 
 * Magdalena Szlapczynski
 *  Last Modified: Apr.19, 2025
 */

using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasShadeTargetCT : ConditionTask
{
    public BBParameter<ZombieController> zombieController;

    protected override bool OnCheck()
    {
        if (zombieController.value.Target != null)
        {
            return zombieController.value.Target.tag == "Shade";
        }
        return false;
    }
}
