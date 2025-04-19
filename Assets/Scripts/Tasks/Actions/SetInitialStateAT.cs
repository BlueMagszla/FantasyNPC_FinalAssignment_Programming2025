using NodeCanvas.Framework;
using UnityEngine;

public class SetInitialStateAT : ActionTask
{
    public BBParameter<Animator> zombieAnimator;
    public BBParameter<bool> isWalking;
    public BBParameter<bool> isIdle;

    protected override void OnExecute()
    {
        Animator animator = zombieAnimator.value;

        float chanceToWalk = animator.GetComponent<ZombieController>().ChanceToWalk;

        //if (Random.value <= chanceToWalk)
        //{
        //    animator.SetTrigger(ZombieController.RunParamHash);
        //    isWalking.value = true;
        //    isIdle.value = false;
        //}
        //else
        //{
        //    animator.SetTrigger(ZombieController.IdleParamHash);
        //    isWalking.value = false;
        //    isIdle.value = true;
        //}
        
        EndAction(true);
    }
}
