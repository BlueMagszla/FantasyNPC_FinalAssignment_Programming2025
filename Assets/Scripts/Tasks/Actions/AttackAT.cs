using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

public class AttackAT : ActionTask
{
    public BBParameter<NavMeshAgent> navAgent;
    public BBParameter<Animator> animator;

    private MeganController meganController;

    protected override string OnInit()
    {
        meganController = GameObject.FindGameObjectWithTag("Player").GetComponent<MeganController>();

        return base.OnInit();
    }

    protected override void OnExecute()
    {
        navAgent.value.ResetPath();

        animator.value.SetTrigger(ZombieController.AttackParamHash);

        meganController.DieAndRestart();
    }
}
