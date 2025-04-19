using NodeCanvas.Framework;
using ParadoxNotion.Serialization.FullSerializer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFallAT : ActionTask
{
    public BBParameter<ZombieController> zombieController;
    public Animator zombieAnim;
    public BBParameter<NavMeshAgent> navAgent;

    public BBParameter<bool> isWalking;
    public BBParameter<bool> isIdle;
    protected override void OnExecute()
    {
        playAnimation();
        
    }
    public void playAnimation()
    {
        isWalking.value = false;
        isIdle.value = false;
        navAgent.value.isStopped = true;
        zombieAnim.SetTrigger(ZombieController.FallParamHash);
        zombieController.value.gameObject.transform.position += new Vector3(0f, -1f, 0f);

    }
}
