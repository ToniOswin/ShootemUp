using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float speed = 4;
    public int damage;
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("sa chocao con el jugador");
            GameManager.gameM.LostHealth(damage);
            Destroy(gameObject);
        }
    }
}
