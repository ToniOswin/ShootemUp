using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Canvas tutorialCanvas;
    [SerializeField]
    Canvas MenuCanvas;
    [SerializeField]
    TextMeshProUGUI recordText;
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    private void Start()
    {
        recordText.text = "Record: " + PlayerPrefs.GetInt("MaxPuntuation", 0).ToString();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Showtutorial()
    {
        tutorialCanvas.gameObject.SetActive(true);
        MenuCanvas.gameObject.SetActive(false);
    }

    public void CloseTutorial()
    {
        tutorialCanvas.gameObject.SetActive(false);
        MenuCanvas.gameObject.SetActive(true);
    }
}
