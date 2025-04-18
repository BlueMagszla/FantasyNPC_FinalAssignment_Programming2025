using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

public class ChaseAT : ActionTask
{
    public BBParameter<ZombieController> zombieController;
    public BBParameter<NavMeshAgent> navAgent;

    private Transform target;

    protected override void OnExecute()
    {
        target = zombieController.value.Target;
        SetDestination();
    }

    protected override void OnUpdate()
    {
        if (navAgent.value.hasPath)
        {
            Vector3 desiredDirection = (navAgent.value.steeringTarget - agent.transform.position);

            Quaternion desiredRotation = Quaternion.LookRotation(desiredDirection);
            agent.transform.parent.rotation = Quaternion.Lerp(agent.transform.parent.rotation, desiredRotation, 6 * Time.deltaTime);

            float distanceRemaining = Vector3.Distance(agent.transform.position, navAgent.value.destination);
            if (distanceRemaining < zombieController.value.AttackRadius) EndAction(true);

            SetDestination();
        }
    }

    private void SetDestination()
    {
        navAgent.value.SetDestination(target.position);
    }
}
