using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject PauseMenuParentUi;
    public GameObject PauseMenuUi;

    private void Start()
    {
        Resume();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (!IsGamePaused)
            Pause();
        else
            Resume();
    }

    public void Resume()
    {
        PauseMenuUi.SetActive(true);
        PauseMenuParentUi.SetActive(false);
        Time.timeScale = 1.0f;
        IsGamePaused = false;
    }

    private void Pause()
    {
        PauseMenuUi.SetActive(true);
        PauseMenuParentUi.SetActive(true);
        Time.timeScale = 0.0f;
        IsGamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void LoadLevelManager()
    {
        SceneManager.LoadScene(1);
        Destroy(gameObject);
    }
}