using NodeCanvas.Framework;
using UnityEngine;

public class ResetTargetAT : ActionTask
{
    public BBParameter<ZombieController> zombieController;

    protected override void OnExecute()
    {
        zombieController.value.Target = null;
        EndAction(true);
    }
}
