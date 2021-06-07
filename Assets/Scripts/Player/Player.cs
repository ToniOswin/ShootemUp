using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rB;
    [SerializeField]
    float speed;

    Animator playerAnim;
    void Start()
    {
        rB = gameObject.GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
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
            GameManager.gameM.LostHealth(other.gameObject.GetComponent<Bullet>().damage);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("PointedBullet"))
        {
            GameManager.gameM.LostHealth(other.gameObject.GetComponent<ShootToPlayer>().damage);
            Destroy(other.gameObject);
        }

        if( GameManager.gameM.PlayerHealth<=0)
        {
            GameManager.gameM.PlayerDie();
        }
    }

}
