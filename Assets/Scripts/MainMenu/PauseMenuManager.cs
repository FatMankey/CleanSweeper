using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject PauseMenuParentUI;
    public GameObject PauseMenuUI;
    public GameObject OptionMenuUI;

    private void Start()
    {
        Resume();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
                Pause();
            else
                Resume();
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(true);
        PauseMenuParentUI.SetActive(false);
        Time.timeScale = 1.0f;
        isGamePaused = false;
    }

    private void Pause()
    {
        OptionMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
        PauseMenuParentUI.SetActive(true);
        Time.timeScale = 0.0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}