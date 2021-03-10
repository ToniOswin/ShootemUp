using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Shoot shootScript;
    // Start is called before the first frame update
    void Start()
    {
        shootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();
        StartCoroutine(Dissapear());
    }

    // Update is called once per frame
    void Update()
    {
        
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
