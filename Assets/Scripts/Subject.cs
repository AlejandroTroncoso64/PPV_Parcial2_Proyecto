using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Habilitar/crear menú para insertar scriptable objects
[CreateAssetMenu(fileName = "New Subject", menuName = "ScriptableObjects/New_Lesson", order = 1)]

//Consulta y manipulación de datos
public class Subject : ScriptableObject
{
    
    [Header("GameObject Configuration")]
    public int Lesson = 0;

    [Header("Lesson Quest Configuration")]
    public List<Leccion> leccionList;
}
