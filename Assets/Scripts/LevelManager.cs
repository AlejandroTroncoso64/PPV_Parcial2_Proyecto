using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    
    //Instancia de la clase
    public static LevelManager Instance;

    //Variable de número de lección
    [Header("Level Data")]
    public Subject Lesson;

    //Variables de información de la UI
    [Header("User Interface")]
    public TMP_Text QuestionTxt; //Pregunta
    public TMP_Text livesTxt; //Contador de vidas
    public List<Option> Options; //Opciones de la pregunta
    public GameObject CheckButton; //Botón de comprobar
    public GameObject AnswerContainer; //Respuesta correcta
    public Color red;
    public Color green;

    //Información de las preguntas y estatus del jugador, se comienza a contar desde cero
    [Header("Game Configuration")]
    public int questionAmount = 0; //Preguntas totales de la lección
    public int currentQuestion = 0; //Pregunta actual
    public string question; //Texto de la pregunta
    public string correctAnswer; //Respuesta correcta
    public int answerFromPlayer = 9; //Respuesta del jugador
    public int lives = 5; //Vidas del jugador

    //Lección actual
    [Header("Current Lesson")]
    public Leccion currentLesson;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    
    void Start()
    {
        questionAmount = Lesson.leccionList.Count;
        LoadQuestion();
        CheckPlayerState();
        //Revisar cantidad de preguntas, cargar la pregunta correspondiente y verificar estatus del jugador
    }

    private void LoadQuestion()
    {
        if (currentQuestion < questionAmount)
        {
            //Establecer datos de pregunta, de qué lección, la pregunta, la respuesta correcta y el texto de la pregunta
            currentLesson = Lesson.leccionList[currentQuestion];
            question = currentLesson.lessons;
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            QuestionTxt.text = question;

            //Opciones de respuesta de la pregunta
            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                Options[i].GetComponent<Option>().OptionName = currentLesson.options[i];
                Options[i].GetComponent<Option>().OptionID = i;
                Options[i].GetComponent<Option>().UpdateText();
            }
        }
        else
        {
            //Al terminar las preguntas, notificar por un debug log
            Debug.Log("Fin de las preguntas");

        }
    }

    //Verificar si una pregunta es correcta o incorreta, actualizar el estatus del jugador y cambiar color de los botones
    public void NextQuestion()
    {
        if (CheckPlayerState())
        {

            bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

            AnswerContainer.SetActive(true);

            if (isCorrect)
            {
                AnswerContainer.GetComponent<Image>().color = Color.green;
                Debug.Log("Respuesta Correcta" + ": " + correctAnswer);
            }
            else
            {

                AnswerContainer.GetComponent<Image>().color = Color.red;
                Debug.Log("Respuesta Incorrecta.  " + question + ": " + correctAnswer);
                lives--;
            }

            //Actualizar número de vidas
            livesTxt.text = lives.ToString();
            //Cambiar ID a la pregunta siguiente
            currentQuestion++;
            StartCoroutine(ShowResultAndLoadQuestion(isCorrect));
            answerFromPlayer = 9;
        }
        else
        {
            
        }

    }

    //Mostrar la respuesta y cargar la siguiente pregunta
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        yield return new WaitForSeconds(3f);
        AnswerContainer.SetActive(false);
        LoadQuestion();
        CheckPlayerState();
    }

    public void SetPlayerAnswer(int _answer)
    {
        answerFromPlayer = _answer;
    }

    //Cambiar apariencia (color) del botón por selección del jugador
    public bool CheckPlayerState()
    {

        if (answerFromPlayer != 9)
        {
            CheckButton.GetComponent<Button>().interactable = true;
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else
        {
            CheckButton.GetComponent<Button>().interactable = false;
            CheckButton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }

}