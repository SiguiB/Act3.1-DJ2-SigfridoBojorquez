using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour
{
   
    public void Newgame() {
        SceneManager.LoadScene("Level1");
    }
    public void Salir() {
        Application.Quit();
    }
}