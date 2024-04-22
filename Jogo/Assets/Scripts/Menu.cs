using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Vida vida;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BackMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public Transform pauseMenu;
    public void CameraLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CameraUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseMenu.gameObject.activeSelf)
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
                CameraLock();
            }
            else
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                CameraUnlock();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        CameraLock();
    }

    public Transform gameOver;
    public void GameOver()
    {
        if (vida.GetComponent<Vida>().vidaTotal <= 0)
        {
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
            CameraUnlock();
        }          
    }
    public void RestartGame()
    {
        gameOver.gameObject.SetActive(false);
        Time.timeScale = 1;
        CameraLock();
    }

}
