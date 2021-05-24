using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rB;
    [SerializeField]
    float speed;

    Shoot shootScript;
    Animator playerAnim;
    GameManager gm;
    void Start()
    {
        shootScript = GetComponent<Shoot>();
        rB = gameObject.GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        rB.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0));
        rB.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed * Time.deltaTime));
        playerAnim.SetFloat("VerticalInput", Input.GetAxis("Vertical"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            gm.LostHealth(other.gameObject.GetComponent<Bullet>().damage);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("PointedBullet"))
        {
            gm.LostHealth(other.gameObject.GetComponent<ShootToPlayer>().damage);
            Destroy(other.gameObject);
        }

        if(gm.PlayerHealth <= 0)
        {
            gm.PlayerDie();
        }
    }

}
