using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Shoot shootScript;
    void Start()
    {
        shootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();
        StartCoroutine(Dissapear());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && shootScript.numberOfShoots <4)
        {
            shootScript.numberOfShoots++;
            Destroy(gameObject);
        }
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
