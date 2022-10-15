using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMenu : MonoBehaviour
{
    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void ReiniciarJuego2()
    {
        SceneManager.LoadScene("MiniGame2");
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
