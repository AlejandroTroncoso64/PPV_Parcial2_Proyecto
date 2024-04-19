using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    //Variable de nombre de escena a cambiar
    public string nombreDeLaEscena;

    //Realizar cambio de escena
    public void CambiarAEscena()
    {
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}