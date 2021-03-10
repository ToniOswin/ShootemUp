using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyPattern;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            int rand = Random.Range(0, enemyPattern.Length);
            GameObject thisPattern = Instantiate(enemyPattern[rand], transform.position, Quaternion.identity);
            Destroy(thisPattern, 1f);
        }
    }
}
