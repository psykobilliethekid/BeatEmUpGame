using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;

    private Rigidbody myBody;
    public float speed = 5f;

    private Transform playerTarget;

    public float attack_Distance = 1f;
    private float chase_Player_After_Attack = 1f;

    private float current_Attack_Time;
    private float default_Attack_Time = 2f;

    private bool followPlayer, attackPlayer;


    void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Enemy will attack the player when it gets
        // to the player's location
        followPlayer = true;
        current_Attack_Time = default_Attack_Time;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void FixedUpdate()
    {
        FollowTarget();
    }

    // Target and follow the player
    void FollowTarget()
    {
        // If not supposed to follow the player
        // will exit out of the method
        if (!followPlayer)
            return;

        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance)
        {
            // Look in direction of the player and move towards player
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            // Means the enemy is moving
            if (myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }

        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            // Automatically stops enemy movement
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }

    }

    // Attack the player
    void Attack()
    {
        // If enemy should NOT attack the player
        // exit the method 
        if (!attackPlayer)
            return;

        current_Attack_Time += Time.deltaTime;

        if (current_Attack_Time > default_Attack_Time)
        {
            // Will return 0, 1, 2 for enemy attack
            enemyAnim.EnemyAttack(Random.Range(0, 3));

            // Reset the current attack value
            current_Attack_Time = 0f;
        }


        // Gives player time before they are attacked
        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance + chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
