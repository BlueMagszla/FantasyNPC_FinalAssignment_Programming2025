//ms

using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

public class VillagerWalkToAT : ActionTask
{
    public BBParameter<VillagerController> villagerController;
    public Animator villagerAnim;

    public BBParameter<NavMeshAgent> navAgent;
    public BBParameter<bool> isWalking;
    public BBParameter<bool> isIdle;

    private Transform target;

    private float stoppingDistance = 0.5f;

    protected override void OnExecute()
    {
        isWalking.value = true;
        isIdle.value = false;
        target = villagerController.value.Target;
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

            SetDestination();

            if (Vector3.Distance(villagerController.value.gameObject.transform.position, villagerController.value.Target.position) <= stoppingDistance)
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
        villagerAnim.SetTrigger(VillagerController.RunParamHash);
        villagerController.value.gameObject.transform.position += new Vector3(0f, -1f, 0f);

    }


}
