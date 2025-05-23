//ms copy

using NodeCanvas.BehaviourTrees;
using NodeCanvas.Framework;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [field: SerializeField] public float ChanceToWalk { get; private set; } = 0.3f;
    [field: SerializeField] public float WanderDistance { get; private set; } = 7.5f;
    [field: SerializeField] public float WanderRadius { get; private set; } = 3f;
    [field: SerializeField] public float AttackRadius { get; private set; } = 1f;

    public Transform Target { get; set; }

    public static readonly int RunParamHash = Animator.StringToHash("isWalking");
    public static readonly int AttackParamHash = Animator.StringToHash("isAttacking");
    public static readonly int FallParamHash = Animator.StringToHash("isFalling");
    public static readonly int IdleParamHash = Animator.StringToHash("isIdle");

    public static readonly string ZombieScreamStateName = "Zombie Scream";

    public Blackboard BBref;

    public int health = 14; //health to recieve sunlight damage 
    public float time = 0;
    
    public void OnValidate()
    {
        ChanceToWalk = Mathf.Clamp01(ChanceToWalk);
    }

    public void Awake()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    public void Update()
    {
        animator.SetBool("isWalking", (bool)BBref.GetVariable("isWalking", typeof(bool)).value);
        animator.SetBool("isIdle", (bool)BBref.GetVariable("isIdle", typeof(bool)).value);
        //print(GetComponent<NavMeshAgent>().destination);
    }
}
