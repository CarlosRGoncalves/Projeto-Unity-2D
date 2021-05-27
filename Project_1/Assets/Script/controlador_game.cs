using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controlador_game : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject finish;
    public GameObject pause;


    public static controlador_game instance;
    void Start()
    {
      instance = this;
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
    }
    public void Reiniciar_Jogo(){
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
     public void sair(){
        Application.Quit();
    }
    public void ShowFinish(){
        finish.SetActive(true);

    }
    public void ShowPause(){
        pause.SetActive(true);

    }
    public void ShowContinue(){
        pause.SetActive(false);

    }
}

