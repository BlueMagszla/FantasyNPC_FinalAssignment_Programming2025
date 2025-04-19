using NodeCanvas.Framework;
using UnityEngine;

public class WaitForScreamAT : ActionTask
{
    public BBParameter<Animator> animator;

    protected override void OnExecute()
    {
     //   animator.value.SetTrigger(ZombieController.AlertedParamHash);
    }

    protected override void OnUpdate()
    {
        if (!animator.value.GetCurrentAnimatorStateInfo(0).IsName(ZombieController.ZombieScreamStateName))
            EndAction(true);
    }
}
