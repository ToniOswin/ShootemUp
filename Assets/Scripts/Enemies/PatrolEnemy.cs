using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Transform[] moveSpots;
    int randomSpot;

    float waitTime;
    [SerializeField]
    float startWaitTime;
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);   
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f && moveSpots.Length > 1)
        {
            int lastPos = randomSpot;
            if(waitTime <= 0)
            {
                CheckRan(lastPos);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void CheckRan(int lastPos)
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        if (randomSpot == lastPos)
        {
            CheckRan(lastPos);
        }
    }
}
