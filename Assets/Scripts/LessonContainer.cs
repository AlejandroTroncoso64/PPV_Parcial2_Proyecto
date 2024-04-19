using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Adicion de librerias Unity UI y TMPro

public class LessonContainer : MonoBehaviour
{
    [Header("GameObject Configuration")]
    public int Lesson;
    public int CurrentSection = 0;
    public int CurrentLesson = 0;
    public int TotalLessons = 0;
    //Declaración de variables para conocer cual es la seccion y leccion actual y el total

    public bool AreAllLessonsComplete = false;

    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;

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
    public void OnUpdateUI()
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
