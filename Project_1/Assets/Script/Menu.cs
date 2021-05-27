using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour{
    //public string Cena;

    public void mudarCena(){
        SceneManager.LoadScene(1);
    }
    public void sair(){
        Application.Quit();
    }
}