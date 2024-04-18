using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Leccion
{
    //Variables para lecciones
    public int ID; //Numero de ID de la pregunta
    public string lessons; //Texto de la pregunta
    public List<string> options; //Lista de las opciones de la pregunta
    public int correctAnswer; //Indicador de cual es la respuesta correcta
}
