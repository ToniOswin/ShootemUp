using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Dissapear());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Shoot.playerShoot.numberOfShoots <4)
        {
            Shoot.playerShoot.numberOfShoots++;
            Destroy(gameObject);
        }
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
