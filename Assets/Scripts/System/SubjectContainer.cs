using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//Contenedor de temas, que llamara a las lecciones correspondientes
public class SubjectContainer
{

    [Header("GameObject Configuration")]
    [SerializeField]
    public int Lesson = 0;
    
    [Header("Lesson Quest Configuration")]
    [SerializeField]
    public List<Leccion> leccionList;

}