using NodeCanvas.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MeganController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Animator animator;

    [SerializeField] private Blackboard globalBlackboard;

    private bool isRunning = false;

    public static readonly int DistanceParam = Animator.StringToHash("Distance Remaining");
    public static readonly int RunningParam = Animator.StringToHash("Is Running");
    public static readonly int FinishedParam = Animator.StringToHash("Finished");
    public static readonly int DeadParam = Animator.StringToHash("Dead");

    public void Awake()
    {
        if (!navAgent) navAgent = GetComponent<NavMeshAgent>();
        if (!animator) animator = GetComponent<Animator>();
    }

    public void Update()
    {
        ProcessInput();
        Move();
    }

    private void ProcessInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hit))
            {
                if (hit.collider != null)
                {
                    navAgent.SetDestination(hit.point);
                }
            }
        }
    }

    private void Move()
    {
        if (navAgent.hasPath)
        {
            Vector3 desiredDirection = (navAgent.steeringTarget - transform.position);

            Quaternion desiredRotation = Quaternion.LookRotation(desiredDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, 6 * Time.deltaTime);

            if (!isRunning)
            {
                isRunning = true;
                animator.SetBool(RunningParam, true);
            }

            float distanceRemaining = Vector3.Distance(transform.position, navAgent.destination);
            animator.SetFloat(DistanceParam, distanceRemaining);

            if (distanceRemaining < navAgent.stoppingDistance)
            {
                navAgent.ResetPath();
                isRunning = false;
                animator.SetBool(RunningParam, false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            tag = "Untagged";
            EscapeAndRestart();
        }
    }

    public void EscapeAndRestart()
    {
        animator.SetTrigger(FinishedParam);

        globalBlackboard.SetVariableValue("meganEscaped", true);

        StartCoroutine(RestartScene(4f));
    }

    public void DieAndRestart()
    {
        animator.SetTrigger(DeadParam);

        StartCoroutine(RestartScene(6f));
    }

    private IEnumerator RestartScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
