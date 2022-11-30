using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    [SerializeField] protected private GameObject canvas;
    [SerializeField] protected private GameObject canvasOptions;
    [SerializeField] protected private GameObject canvasRecord;
    [SerializeField] protected private TMP_InputField playerName;
    [SerializeField] protected private Slider sliderMusic;
    [SerializeField] protected private Slider sliderEffects;
    [SerializeField] protected private TextMeshProUGUI topPlayerText;

    private void Start()
    {
        LoadNameAndScore();
    }

    public void SaveName()
    {
        MainManager.Instance.PlayerName = playerName.text;
        MainManager.Instance.VolumeMusic = sliderMusic.value;
        MainManager.Instance.VolumeEffects = sliderEffects.value;
        MainManager.Instance.SaveNameAndScore();
    }
    public void LoadNameAndScore()
    {
        MainManager.Instance.LoadNameAndScore();
        sliderMusic.value = MainManager.Instance.VolumeMusic;
        sliderEffects.value = MainManager.Instance.VolumeEffects;
        playerName.text = MainManager.Instance.PlayerName;
        topPlayerText.text = MainManager.Instance.PlayerName +": " + MainManager.Instance.Wave + " waves";
    }

    public void GoToRecord()
    {
        canvas.gameObject.SetActive(false);
        canvasRecord.gameObject.SetActive(true);
    }

    public void RecordBackToMenu()
    {
        canvasRecord.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }

    public void GoToOptions()
    {
        canvas.gameObject.SetActive(false);
        canvasOptions.gameObject.SetActive(true);
    }
    public void BackToMenu()
    {
        SaveName();
        canvasOptions.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SaveName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
