using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol_Chase : MonoBehaviour
{
    public Transform[] moveSpots;
    private int randomSpot;

    private float waitTime;
    public float startWaitTime = 15f;

    NavMeshAgent nav;

    public float chaseRadius = 20f;
    public float facePlayerFactor = 20f;

    public Transform goal;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
    }

    void Start()
    {
        waitTime = startWaitTime;
        var randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        float distance = Vector3.Distance(PLAYERCONTROLLER.playerPos, transform.position);
        if (distance > chaseRadius)
        {
            Patrol();
        }
        else if(distance <= chaseRadius)
        {
            ChasePlayer();
            FacePlayer();
        }
    }

    void Patrol()
    {
        nav.SetDestination(moveSpots[randomSpot].position);
        if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
        {
            if(waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else { waitTime -= Time.deltaTime; }
        }
    }

    void ChasePlayer()
    {
        float distance = Vector3.Distance(PLAYERCONTROLLER.playerPos, transform.position);

        if (distance <= chaseRadius)
        {
            nav.SetDestination(PLAYERCONTROLLER.playerPos);
        }
    }

    //maybe not needed
    void FacePlayer()
    {
        Vector3 direction = (PLAYERCONTROLLER.playerPos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
    }


}
