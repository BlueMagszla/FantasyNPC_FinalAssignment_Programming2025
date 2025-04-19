/* Target Village
 * 
 * Script handles for zombies to target a spot in the shade.
 * 
 * Magdalena Szlapczynski
 *  Last Modified: Apr.19, 2025
 */


using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetVillage : ActionTask
{
    public BBParameter<ZombieController> zombieController;
    protected override void OnExecute()
    {
        zombieController.value.Target = GameManager.instance.getVillageTarget(); //get village spot
    }
}
