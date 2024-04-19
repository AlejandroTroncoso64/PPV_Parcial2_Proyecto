using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystems : MonoBehaviour
{
    public static SaveSystems instance;

    public SubjectContainer subject;
    public Leccion data;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        else
        {
            instance = this;
        }

        subject = LoadFromJSON<SubjectContainer>(PlayerPrefs.GetString("SelectedLesson"));
    }

    public void SaveToJson(string _fileName, object _data)
    {
        if (_data != null)
        {
            string JSONData = JsonUtility.ToJson(_data, true);

            if (JSONData.Length != 0)
            {
                Debug.Log("JSON STRING: " + JSONData);
                string fileName = _fileName + ".json";
                string filePath = Path.Combine(Application.dataPath + "/StreamingAssets/" + fileName);
                File.WriteAllText(filePath, JSONData);
                Debug.Log("JSON almacenado en la direcci�n: " + filePath);
            }

            else
            {
                Debug.LogWarning("ERROR - FileSystem: JSONData is empty, check for local variable [string JSONData]");
            }
        }

        else
        {
            Debug.LogWarning("ERROR - FileSystmen: _data is null, check for param [obect _data");
        }
    }

    public void CreateFile(string _name, string _extension)
    {
        //Se define en que lugar se guardara el archivo de guardado, su nombre de archivo y extension
        string path = Application.dataPath + "/" + _name + _extension;
        //Verificar si ya existe o no un archivo de guardado
        if (!File.Exists(path))
        {
            //Definir el contenido del guardado
            string content = "Login Rate: " + System.DateTime.Now + "\n";
            string position = "X: " + transform.position.x + "Y: " + transform.position.y;
            //Almacenar el contenido
            File.AppendAllText(path, position);
        }

        else
        {
            //Advertir que se esta intentando crear un archivo con el mismo nombre    
            Debug.LogWarning("Atencion: Est�s tratando de crear un archivo con el mismo nombre [" + _name + _extension + "], verifica tu informaci�n.");
        }
    }

    /*public void Start()
    {
        SaveToJson("LeccionDummy", data);
        CreateFile("Eilan", ".data");

        subject = LoadFromJSON<SubjectContainer>("LeccionDummy");
    }*/

    public T LoadFromJSON<T>(string _fileName) where T : new()
    {
        T Dato = new T();
        string path = Application.dataPath + "/StreamingAssets/" + _fileName + ".json";
        string JSONData = "";
        if (File.Exists(path))
        {
            JSONData = File.ReadAllText(path);
            Debug.Log("JSON STRING: " + JSONData);
        }

        if (JSONData.Length != 0)
        {
            JsonUtility.FromJsonOverwrite(JSONData, Dato);
        }

        else
        {
            Debug.LogWarning("ERROR - FileSystem: JSONData is empty, check for local variable [string JSONData]");
        }

        return Dato;
    }

    string ReadFile(string _fileName, string _extension)
    {
        string path = Application.dataPath + "/StreamingAssets/" + _fileName + _extension;
        string data = "";
        if (File.Exists(path))
        {
            data = File.ReadAllText(path);
        }

        return data;
    }
}