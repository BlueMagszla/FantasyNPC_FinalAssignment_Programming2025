//ms 2 copy

using NodeCanvas.Framework;
using UnityEngine;

public class VillagerController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public Transform Target { get; set; }

    public GameObject Bed;
    public GameObject Work; //job
    public float health = 20;

    public static readonly int RunParamHash = Animator.StringToHash("isWalking");
    public static readonly int AttackParamHash = Animator.StringToHash("isAttacking");
    public static readonly int FallParamHash = Animator.StringToHash("isFalling");
    public static readonly int IdleParamHash = Animator.StringToHash("isIdle");


    public Blackboard BBref;

    public void Start()
    {
        //Bed = GameManager.instance.getRandomBed().Assign().gameObject;
        //Work = GameManager.instance.getRandomJob().Assign().gameObject;
    }

    public void Update()
    {
        if (Bed == null) { Bed = GameManager.instance.getRandomBed().Assign().gameObject; }
        if (Work == null) { Work = GameManager.instance.getRandomJob().Assign().gameObject; }
        animator.SetBool("isWalking", (bool)BBref.GetVariable("isWalking", typeof(bool)).value);
        animator.SetBool("isIdle", (bool)BBref.GetVariable("isIdle", typeof(bool)).value);
    }

    public void Awake()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
}

