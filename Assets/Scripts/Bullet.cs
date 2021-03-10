using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public Vector2 direction;
    public int damage;
    private void OnEnable()
    {
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
