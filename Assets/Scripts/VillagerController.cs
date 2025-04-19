/*Villager Controller Script
 * 
 * Script handles villager animations and assigning a job/bed.
 * 
 * Modified from Professor's lectures
 * Magdalena Szlapczynski
 */

using UnityEngine;

public class VillagerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [field: SerializeField] public float ChanceToWalk { get; private set; } = 0.3f;
    [field: SerializeField] public float WanderDistance { get; private set; } = 7.5f;
    [field: SerializeField] public float WanderRadius { get; private set; } = 3f;
    [field: SerializeField] public float AttackRadius { get; private set; } = 1f;

    public Transform Target { get; set; }

    public GameObject Bed;
    public GameObject Work; //job


    public static readonly int RunParamHash = Animator.StringToHash("isRunning");
    public static readonly int WorkParamHash = Animator.StringToHash("isWorking");
    public static readonly int IdleParamHash = Animator.StringToHash("isIdle");
    public static readonly int WalkParamHash = Animator.StringToHash("isWalking");


    public void Start()
    {
        Bed = GameManager.instance.getRandomBed().Assign().gameObject;
        Work = GameManager.instance.getRandomJob().Assign().gameObject;
    }

    public void Awake()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
}

