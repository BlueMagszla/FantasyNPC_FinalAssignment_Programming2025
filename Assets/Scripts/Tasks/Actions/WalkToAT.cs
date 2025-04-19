//ms

using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

public class WalkToAT : ActionTask
{
    public BBParameter<ZombieController> zombieController;
    public Animator zombieAnim;

    public BBParameter<NavMeshAgent> navAgent;
    public BBParameter<bool> isWalking;
    public BBParameter<bool> isIdle;

    private Transform target;

    private float stoppingDistance = 5f;

    protected override void OnExecute()
    {
        isWalking.value = true;
        isIdle.value = false;
        target = zombieController.value.Target;
        SetDestination();
    }

    protected override void OnUpdate()
    {
        if (navAgent.value.hasPath)
        {
            isWalking.value = true;
            isIdle.value = false;

            Vector3 desiredDirection = (navAgent.value.steeringTarget - agent.transform.position);

            Quaternion desiredRotation = Quaternion.LookRotation(desiredDirection);
            agent.transform.parent.rotation = Quaternion.Lerp(agent.transform.parent.rotation, desiredRotation, 6 * Time.deltaTime);

            float distanceRemaining = Vector3.Distance(agent.transform.position, navAgent.value.destination);
            if (distanceRemaining < zombieController.value.AttackRadius) EndAction(true);

            SetDestination();

            if (Vector3.Distance(zombieController.value.gameObject.transform.position, zombieController.value.Target.position) <= stoppingDistance)
            {
                isWalking.value = false;
                isIdle.value = true;
                EndAction(true);
            }
        }
    }

    private void SetDestination()
    {
        navAgent.value.SetDestination(target.position);
    }

    public void playAnimation()
    {
        navAgent.value.isStopped = true;
        zombieAnim.Play(ZombieController.RunParamHash);
        zombieController.value.gameObject.transform.position += new Vector3(0f, -1f, 0f);

    }


}
