//ms copy

using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [field: SerializeField] public float ChanceToWalk { get; private set; } = 0.3f;
    [field: SerializeField] public float WanderDistance { get; private set; } = 7.5f;
    [field: SerializeField] public float WanderRadius { get; private set; } = 3f;
    [field: SerializeField] public float AttackRadius { get; private set; } = 1f;

    public Transform Target { get; set; }

    public static readonly int AlertedParamHash = Animator.StringToHash("Alerted");
    public static readonly int AttackParamHash = Animator.StringToHash("Attack");
    public static readonly int WalkParamHash = Animator.StringToHash("Walk");
    public static readonly int IdleParamHash = Animator.StringToHash("Idle");

    public static readonly string ZombieScreamStateName = "Zombie Scream";

    public void OnValidate()
    {
        ChanceToWalk = Mathf.Clamp01(ChanceToWalk);
    }

    public void Awake()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
}
