using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    int numberOfShoots;
    [SerializeField]
    int starterlimit;
    [SerializeField]
    AudioClip shootSound;
    AudioClip dieSound;
    int limit;
    AudioSource enemySource;

    // Start is called before the first frame update
    void Start()
    {
        enemySource = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>();
        limit = starterlimit;
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShootBullet(int shootsNumber)
    {
        enemySource.clip = shootSound;
        enemySource.Play();
        if(shootsNumber == 1)
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
        else if(shootsNumber == 2)
        {
            bullet.GetComponent<Bullet>().direction = new Vector2(-1, 0);
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 0.5f), bullet.transform.rotation);
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y -0.5f), bullet.transform.rotation);
        }
    }

    IEnumerator Shooting()
    {
        if(limit >0)
        {
            ShootBullet(numberOfShoots);
            limit -= 1;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Shooting());
        }
        else
        {
            yield return new WaitForSeconds(3);
            limit = starterlimit;
            StartCoroutine(Shooting());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(Shooting());
    }
}
