using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float life;
    public int points;
    GameManager gameM;
    Shoot shootScript;

    public bool DropsPU;
    [SerializeField]
    GameObject powerUp;
    void Start()
    {
        gameM = GameObject.Find("GameManager").GetComponent<GameManager>();
        shootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            life -= other.gameObject.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);
            if (life <= 0)
            {
                Die();
            }
        }
    }

    void DropPowerUp()
    {
        Instantiate(powerUp, transform.position, powerUp.transform.rotation);
    }

    void Die()
    {
        gameM.ExplosionPS(gameObject.transform);
        if(DropsPU == true && shootScript.numberOfShoots <4 && GameObject.FindGameObjectWithTag("PowerUp") == null)
        {
            DropPowerUp();
        }
        Destroy(gameObject);
        gameM.GetPoints(points);
    }
    private void OnDestroy()
    {
        if(transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
    }   
}
