using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public static Shoot playerShoot = null;

    [SerializeField]
    GameObject proyectilePrefab;
    [SerializeField]
    GameObject GranadePrefab;
    [SerializeField]
    Slider sliderBoom;
    public AudioSource playeSounds;
    [SerializeField]
    AudioClip shootSound;

    public int numberOfShoots;
    public bool HasGranade;


    [SerializeField]
    float maxDelay;
    float delay;

    float maxChargueTime = 20;
    public float chargeTime;
    public List<GameObject> pooledObjects;
    public int amountToPool;

    //delegate
    public delegate void ThrowMegaBombDelegate();
    public event ThrowMegaBombDelegate ThrowMegaBombReleased;

    private void Awake()
    {
        if(playerShoot == null)
        {
            playerShoot = this;
        }
        else if(playerShoot != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        HasGranade = false;
        sliderBoom.maxValue = maxChargueTime;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           ShootBullets(numberOfShoots);
            delay = maxDelay;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            delay -= Time.deltaTime;
            if(delay <= 0)
            {
                ShootBullets(numberOfShoots);
                delay = maxDelay;
            }
        }
        if(Input.GetKeyDown(KeyCode.Q) && HasGranade)
        {
            Granade();
            chargeTime = 0;
            HasGranade = false;
        }

        if(HasGranade == false)
        {
            ChargeGranade();
            sliderBoom.value = chargeTime;
        }
    }

    public void ExplodeGranade()
    {
        ThrowMegaBombReleased?.Invoke();
    }

    void ShootBullets(int numberOfShoots)
    {
        playeSounds.clip = shootSound;
        playeSounds.Play();
        GameObject[] bullets = new GameObject[numberOfShoots];

        if (numberOfShoots == 1)
        {
            Create1Front();
        }
        else if (numberOfShoots == 2)
        {
            Create2Front();
        } 
        else if(numberOfShoots == 3)
        {
            Create1Front();
            Create2Side();
        }
        else if(numberOfShoots == 4)
        {
            Create2Front();
            Create2Side();
        }
    }
    void Create1Front()
    {
        proyectilePrefab.GetComponent<Bullet>().direction = new Vector2(1, 0);
        Instantiate(proyectilePrefab, transform.position, proyectilePrefab.transform.rotation);
    }

    void Create2Front()
    {
        proyectilePrefab.GetComponent<Bullet>().direction = new Vector2(1, 0);
        Instantiate(proyectilePrefab, new Vector2(transform.position.x, transform.position.y + 0.5f), proyectilePrefab.transform.rotation);
        Instantiate(proyectilePrefab, new Vector2(transform.position.x, transform.position.y - 0.5f), proyectilePrefab.transform.rotation);
    }

    void Create2Side()
    {
        proyectilePrefab.GetComponent<Bullet>().direction = new Vector2(1, 1);
        Instantiate(proyectilePrefab, transform.position, proyectilePrefab.transform.rotation);
        proyectilePrefab.GetComponent<Bullet>().direction = new Vector2(1, -1);
        Instantiate(proyectilePrefab, transform.position, proyectilePrefab.transform.rotation);
    }


    void Granade()
    {
        Instantiate(GranadePrefab, transform.position, GranadePrefab.transform.rotation);
        HasGranade = false;
    }

    IEnumerator CharcheBomb()
    {
        yield return new WaitForSeconds(20);
        HasGranade = true;
    }

    void ChargeGranade()
    {
        if(chargeTime >= maxChargueTime)
        {
            HasGranade = true;
        }
        else
        {
            chargeTime += Time.deltaTime;
        }
    }
}
