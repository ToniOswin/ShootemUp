using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PlayerPoints;
    [SerializeField]
    float PlayerMaxHealth;
    public float PlayerHealth;

    [SerializeField]
    TextMeshProUGUI pointsText;
    [SerializeField]
    Slider slider;
    [SerializeField]
    ParticleSystem explosion;
    [SerializeField]
    ParticleSystem explosionGranade;
    [SerializeField]
    AudioClip dieSound;
    [SerializeField]
    AudioSource playerSource;
    [SerializeField]
    Canvas deathCan;
    [SerializeField]
    TextMeshProUGUI PuntuationText;
    [SerializeField]
    TextMeshProUGUI MaxPuntuationText;
    void Start()
    {
        PlayerPoints = PlayerPrefs.GetInt("Points", 0);
        PlayerHealth = PlayerMaxHealth;
        slider.maxValue = PlayerMaxHealth;
        slider.value = PlayerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = PlayerPoints.ToString();
    }

    public void GetPoints(int points)
    {
        PlayerPoints += points;
    }

    public void LostHealth(float Damage)
    {
        PlayerHealth -= Damage;
        SetHealth();
    }
    public void SetHealth()
    {
        slider.value = PlayerHealth;
    }
    public void ExplosionPS(Transform position)
    {
        Instantiate(explosion, position.position, position.rotation);
    }
    public void ExplosionGranade(Transform position)
    {
        Instantiate(explosionGranade, position.position, position.rotation);
    }
    public void PlayerDie()
    {
        PauseGame();
        SetMaxPunt();
        deathCan.gameObject.SetActive(true);
        PuntuationText.text = "Your Points: " + PlayerPoints.ToString();
        MaxPuntuationText.text = PlayerPrefs.GetInt("MaxPuntuation", 0).ToString();
        playerSource.clip = dieSound;
        playerSource.Play();
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    void SetMaxPunt()
    {
        if(PlayerPrefs.GetInt("MaxPuntuation",0) <PlayerPoints)
        {
            PlayerPrefs.SetInt("MaxPuntuation", PlayerPoints);
        }
    }
}
