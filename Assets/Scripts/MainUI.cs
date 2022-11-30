using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] TextMeshProUGUI nameAndScore;
    [SerializeField] TextMeshProUGUI onlineWaveNumber;
    [SerializeField] protected private Slider sliderMusic;
    [SerializeField] protected private Slider sliderEffects;

    [SerializeField] public static bool gameOver;

    [SerializeField] protected private float waveNumber { get; private set; }// ENCAPSULATION
    [SerializeField] protected private string namePlayer { get; private set; }// ENCAPSULATION

    protected private void Awake()
    {
        LoadNameAndScore();
    }

    private void Update()
    {
        WaveNumber();
    }

    private void WaveNumber()//// POLYMORPHISM// ABSTRACTION
    {
        waveNumber = SpawnEnemys.waveNumber;
        onlineWaveNumber.text = namePlayer + " Wave: " + waveNumber;
        if (gameOver == true)
        {
            GameOver();
        }
    }

    public void SaveNameAndScore()
    {
        MainManager.Instance.PlayerName = namePlayer;
        MainManager.Instance.Wave = waveNumber;
        MainManager.Instance.VolumeMusic = sliderMusic.value;
        MainManager.Instance.VolumeEffects = sliderEffects.value;
        MainManager.Instance.SaveNameAndScore();
    }
    public void LoadNameAndScore()
    {
        MainManager.Instance.LoadNameAndScore();
        namePlayer = MainManager.Instance.PlayerName;
        sliderMusic.value = MainManager.Instance.VolumeMusic;
        sliderEffects.value = MainManager.Instance.VolumeEffects;
    }

    public void Pause()// ABSTRACTION
    {
        Time.timeScale = 0;
        pauseCanvas.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void UnPause()// ABSTRACTION
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void BackToMenu()// ABSTRACTION
    {
        SceneManager.LoadScene(0);
    }

    private void GameOver()// ABSTRACTION
    {
        nameAndScore.text = namePlayer + "  Wave:" + waveNumber;
        pauseButton.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
        SaveNameAndScore();
    }

    public void Restart()// POLYMORPHISM
    {
        gameOver = false;
        gameOverCanvas.gameObject.SetActive(false);
        SpawnEnemys.waveNumber = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
