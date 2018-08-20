using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{    
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown levelSelectDropdown;

    Resolution[] resolutions;
    public int selectedLevel;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++) 
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        List<string> levelNames = new List<string>();
        selectedLevel = 1;

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            if (i != 0)
            levelNames.Add("Level " + i);
        }

        levelSelectDropdown.ClearOptions();
        levelSelectDropdown.value = selectedLevel;
        levelSelectDropdown.AddOptions(levelNames);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(selectedLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetResolution( int num )
    {
        Resolution resolution = resolutions[num];
        Screen.SetResolution( resolution.width, resolution.height, Screen.fullScreen );
    }
    public void SetFullScreen( bool isFullScreen )
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetLevel (int num)
    {
        selectedLevel = num + 1;
    }
}
