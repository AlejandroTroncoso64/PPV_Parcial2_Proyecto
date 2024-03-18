using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public int OptionID; //Respuesta correcta
    public string OptionName;

    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }

    //Actualizar el la pregunta en el ScriptableObject
    public void UpdateText()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }
    //Si el jugador selecciona una pregunta, llamar a SetPlayerAnswer y CheckPlayerState.
    public void SelectOptions()
    {
        //Definir respuesta correcta
        LevelManager.Instance.SetPlayerAnswer(OptionID);
        LevelManager.Instance.CheckPlayerState();
    }
}