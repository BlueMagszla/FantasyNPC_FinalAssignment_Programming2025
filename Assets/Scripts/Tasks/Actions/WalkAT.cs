//Professor's Code

using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

public class WalkAT : ActionTask
{
    public BBParameter<ZombieController> zombieController;
    public BBParameter<Animator> animator;
    public BBParameter<NavMeshAgent> navAgent;
    public BBParameter<bool> isWalking;
    public BBParameter<bool> isIdle;

    protected override void OnExecute()
    {
        animator.value.SetTrigger(ZombieController.RunParamHash);
        SetRandomDestination();
    }

    protected override void OnUpdate()
    {
        NavMeshAgent na = navAgent.value;

        if (na.hasPath)
        {
            Vector3 targetDirection = (na.steeringTarget - agent.transform.position);
            Quaternion desiredRotation = Quaternion.LookRotation(targetDirection);

            agent.transform.parent.rotation = Quaternion.Slerp(agent.transform.parent.rotation, desiredRotation, Time.deltaTime);

            if (Vector3.Distance(agent.transform.position, na.destination) < na.stoppingDistance)
                na.ResetPath();
        }
        else if (!na.pathPending)
        {
            if (Random.value > zombieController.value.ChanceToWalk)
            {
                isWalking.value = false;
                isIdle.value = true;
                EndAction(true);
            }
            else
            {
                SetRandomDestination();
            }
        }
        else
        {
            SetRandomDestination();
        }
    }

    protected override void OnStop()
    {
        navAgent.value.ResetPath();
    }

    private void SetRandomDestination()
    {
        ZombieController zc = zombieController.value;

        Vector3 targetPoint = agent.transform.position + agent.transform.forward * zc.WanderDistance;
        Vector2 pointOnCircle = Random.insideUnitCircle.normalized * zc.WanderRadius;

        targetPoint += new Vector3(pointOnCircle.x, 0, pointOnCircle.y);

        if (NavMesh.SamplePosition(targetPoint, out NavMeshHit hit, zc.WanderDistance + zc.WanderRadius, NavMesh.AllAreas))
            targetPoint = hit.position;
        else
            targetPoint = agent.transform.position;

        navAgent.value.SetDestination(targetPoint);
    }

}
