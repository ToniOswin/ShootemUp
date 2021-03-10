using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToPlayer : MonoBehaviour
{
    public float speed = 20;
    Vector2 direction;
    public int damage;
    private void OnEnable()
    {
        StartCoroutine(destroyBullet());
        direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
