using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool pause = false;
    public GameObject PauseMenuPanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void ResumeGame()
    {
        EventSystem.current.SetSelectedGameObject(null);
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }
    void PauseGame()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
        ResumeGame();
    }
}
