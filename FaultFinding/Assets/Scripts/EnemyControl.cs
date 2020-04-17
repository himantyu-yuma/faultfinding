using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour, IBugable
{
    [SerializeField]
    private GameMaster master = default;

    private Transform player;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float speed = 3.5f;

    private Animator animator;

    [SerializeField]
    private EnemyBGMManager bgmManager = default;

    private static bool isBugFixed = false;

    // Start is called before the first frame update
    void Start()
    {
        master = GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = this.GetComponent<NavMeshAgent>();

        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            master.IsOver = true;
            agent.enabled = false;
        }
    }

    public void StartChase()
    {
        this.enabled = true;
        this.gameObject.SetActive(true);
        agent.isStopped = false;
        agent.speed = speed;
        bgmManager.StartBGM();
        if (isBugFixed)
        {
            animator.SetBool("isBugFixed", true);
        }
    }

    public void StopChase()
    {
        this.enabled = false;
        agent.isStopped = true;
        agent.speed = 0;
        this.gameObject.SetActive(false);
        bgmManager.StopBGM();
    }

    public void Pause()
    {
        if (!master.isChase)
        {
            return;
        }

        this.enabled = false;

        agent.isStopped = true;
        agent.speed = 0;
    }

    public void BugFix()
    {
        isBugFixed = true;
        animator.SetBool("isBugFixed", true);
    }
}
