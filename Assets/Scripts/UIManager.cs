using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public RectTransform gameResult;
    public RectTransform currentWaveUI;
    public RectTransform totalWaveUI;
    public RectTransform bulletAmountUI;
    public RectTransform scoreUI;
    public RectTransform highestScoreUI;
    public UnityEngine.UI.Slider fuelSlider;
    public UnityEngine.UI.Slider healthSlider;
    

    public void InitialEndGamePanel(string message)
    {
        gameResult.GetComponent<TextMeshProUGUI>().text = message;
        endGamePanel.SetActive(true);
    }

    public void SetCurrentWave(string txt)
    {
        currentWaveUI.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void SetTotalWave(string txt)
    {
        totalWaveUI.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void SetBulletAmount(string txt)
    {
        bulletAmountUI.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void SetScore(string txt)
    {
        scoreUI.GetComponent<TextMeshProUGUI>().text = txt;
        highestScoreUI.GetComponent<TextMeshProUGUI>().text = txt;
    }

    public void SetFuelSlider(float max ,float value)
    {
        if (max > 0) fuelSlider.maxValue = max;
        fuelSlider.value = value;
    }

    public void SetHealthSlider(float max, float value)
    {
        if (max > 0) healthSlider.maxValue = max;
        healthSlider.value = value;
    }

    public void RestartGame() 
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
