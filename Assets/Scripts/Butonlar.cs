using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Butonlar : MonoBehaviour
{
    public void CikisButonu()
    {
        Application.Quit();
    }
    public void StartButonu()
    {
        SceneManager.LoadScene("game");
    }
    public void RestartButonu()
    {
        SceneManager.LoadScene("Start");
    }
}
