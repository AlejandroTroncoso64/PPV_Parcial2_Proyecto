using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Adicion de librerias Unity UI y TMPro

public class LessonContainer : MonoBehaviour
{
    [Header("GameObject Configuration")]
    //Declaración de variables para conocer cual es la seccion y leccion actual y el total
    public int Lesson; //Numero de la leccion
    public int CurrentLesson = 0; //Numero de la leccion actual
    public int TotalLessons = 0; //Total de lecciones
    public bool AreAllLessonsComplete = false; //Dato para ver si todas las lecciones se completaron o no

    [Header("UI Configuration")]
    public TMP_Text StageTitle; //Titulo de la leccion
    public TMP_Text LessonStage; //Texto de la leccion

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer; //GameObject en unity para el lesson container

    //Datos de cada lección
    [Header("Lesson Data")]
    public ScriptableObject LessonData;

    // Start is called before the first frame update
    void Start()
    {
        if (lessonContainer != null)
        {
        OnUpdateUI();
        }
        else
        {
            Debug.LogWarning("GameObject Null, revisa las variables GameObject lessonContainer");
        }
    }


    //Evento, se consulta al inicio y al presionar el boton, On es para eventos
    public void OnUpdateUI() //Abre y cierra la ventana "lesson container"
    {
        if (StageTitle != null || LessonStage != null) 
        { 
            StageTitle.text = "Leccion " + Lesson;
            LessonStage.text = "Leccion " + CurrentLesson + " de " + TotalLessons;
        }
        //Enviar alerta en caso de tener variables nulas de TMP_Texto
        else
        {
            Debug.LogWarning("GameObject Null, revisa las variables TMP_Text");
        }
    }
    

    //Activar o desactivar ventana de lessonContainer
    public void EnableWindow()
    {
        OnUpdateUI();

        if (lessonContainer.activeSelf)
        {
            //Desactivar objeto si está activo
            lessonContainer.SetActive(false);
        }
        else
        {
            //Activar objeto si está inactivo
            lessonContainer.SetActive(true);
        }
    }
}
