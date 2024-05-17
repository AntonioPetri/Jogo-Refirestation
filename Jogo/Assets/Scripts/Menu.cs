using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public Vida vida;
    [SerializeField] TextMeshProUGUI HordaFinal, PontoFinal;

    // Função dos botões do menu principal
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

    // O jogo funciona normal
    private void Start()
    {
        Time.timeScale = 1;
    }

    public Transform pauseMenu;
    public Transform gameOver;

    // Trava o mouse e some com ele
    public void CameraLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Destrava com o mouse e faz ele aparecer
    public void CameraUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // ESC pausa e morte da GameOver
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

        // DESCOMENTAR PARA O GAMEROVER FUNCIONAR < ----------------------
        if (FindObjectOfType<Vida>().Morto == true)
        {
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
            CameraUnlock();
            
            HordaFinal.text = $"Você chegou até a horda {FindObjectOfType<WaveSpawner>().Horda}";
            PontoFinal.text = $"Pontuação final: {FindObjectOfType<BarraDeVida>().Pontuacao}";
            
        }
    }
    // Tira o pause
    public void ResumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
        CameraLock();
    }

        
    // Restarta
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

}
