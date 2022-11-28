using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvasOptions;
    [SerializeField] GameObject canvasRecord;
    [SerializeField] TMP_InputField playerName;

    private void Start()
    {
        LoadNameAndScore();
    }

    public void SaveName()
    {
        MainManager.Instance.PlayerName = playerName.text;
        MainManager.Instance.SaveNameAndScore();
    }
    public void LoadNameAndScore()
    {
        MainManager.Instance.LoadNameAndScore();
        playerName.text = MainManager.Instance.PlayerName;
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
