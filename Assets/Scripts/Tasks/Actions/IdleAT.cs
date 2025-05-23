using NodeCanvas.Framework;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

public class IdleAT : ActionTask
{
    public BBParameter<ZombieController> zombieController;
    public BBParameter<Animator> animator;
    public BBParameter<bool> isWalking;
    public BBParameter<bool> isIdle;

    public float updateFrequencyInSeconds = 2f;

    private float nextUpdateTime = 0;

    protected override void OnExecute()
    {
        nextUpdateTime = Time.time + updateFrequencyInSeconds;
    }

    protected override void OnUpdate()
    {
        if (Time.time > nextUpdateTime)
        {
            if (Random.value > zombieController.value.ChanceToWalk)
            {
                isWalking.value = true;
                isIdle.value = false;
                EndAction(true);
            }
            else
            {
                nextUpdateTime = Time.time + updateFrequencyInSeconds;
            }
        }
    }
}
