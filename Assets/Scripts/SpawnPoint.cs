using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawn;

    public bool isRandom;
    void Start()
    {
        int rand = Random.Range(0, spawn.Length);
        GameObject thisSpawn = spawn[rand];
        if (!isRandom)
        {
            Instantiate(thisSpawn, transform.position, thisSpawn.transform.rotation);
        }
        else
        {
            Instantiate(thisSpawn, GetRandomPos(), thisSpawn.transform.rotation);
        }
        
        Destroy(gameObject);
    }
    Vector2  GetRandomPos()
    {
        float posX = Random.Range(-9, 9);
        float posY = Random.Range(-5, 5);

        return new Vector2(posX, posY);
    }
}
