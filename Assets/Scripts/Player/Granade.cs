using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    int speed = 10;
    GameManager gameM;
    // Start is called before the first frame update
    void Start()
    {
        gameM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, new Vector2(0, 0)) < 0.2f)
        {
            StartCoroutine(Explode());
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3);
        GameObject[] enemies =  GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        gameM.ExplosionGranade(gameObject.transform);
        Destroy(gameObject);
    }
}
