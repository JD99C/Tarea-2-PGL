using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void IniciarJuego()
    {
        SceneManager.LoadScene("MiniGame");
    }
    public void SalirAplicacion()
    {
        Application.Quit();
    }
}
