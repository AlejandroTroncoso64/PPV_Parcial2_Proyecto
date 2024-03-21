using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

//Singleton, hacer que solo se instancie hacia un objeto
public class SaveSystem : MonoBehaviour
{   
    public static SaveSystem instance;

    public Lesson data;
    //public SubjectContainer subject;

    private void Awake()
    {
        if (instance == null)
        {
            return;   
        }
        else    
        {
            instance = this;
        }
    }

    public void Start()
    {
        CreateFile("PandoraBox", ".data");

        //subject = LoadFromJSON<SubjectAlternativeNameBuilder>("SubjectDummy");
    }

    public void CreateFile(string _name, string _extension)
    {
        //Definición del path del archivo
        string path = Application.dataPath + "/" + _name + _extension;
        //Revisión si el archivo en el path NO existe
        if (!File.Exists(path))
        {
            //Creación del contenido
            string content = "Login Date: " + System.DateTime.Now + "\n";
            //Almacenamiento de la información
            File.AppendAllText(path, content);
        }
        else
        {
            Debug.LogWarning("Atencion: Estas tratando de crear un archivo con el mismo nombre [" + _name + _extension + "], verifica tu información");
        }
    }

    string ReadFile(string _fileName, string _extension)
    {
        //Acceder al path del archivo
        string path = Application.dataPath + "/Resources/" + _fileName + _extension;
        //Si el archivo existe, dame su info
        string data = "";
        if (File.Exists(path))
        {
            data = File.ReadAllText(path);
        }
        return data;
    }
    

    public void SaveToJSON(string _fileName, object _data)
    {
        if (_data != null)
        {
            string JSONData = JsonUtility.ToJson(_data, true);

            if (JSONData.Length != 0)
            {
                Debug.Log("JSON STRING: " + JSONData);
                string fileName = _fileName + ".json";
                string filePath = Path.Combine(Application.dataPath + "/Resources/JSONS/", fileName);
                File.WriteAllText(filePath, JSONData);
                Debug.Log("JSON almacenado en la direccion: " + filePath);
            }
            else
            {
                Debug.LogWarning("ERROR - FileSystem: JSONData is empty, check for local variable [string JSONData]");
            }
        }
        else
        {
            Debug.LogWarning("ERROR - FileSystem: _data is null, check for param [object _data]");
        }
    }
}
