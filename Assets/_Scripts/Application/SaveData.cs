using System.IO;
using UnityEngine;

public class SaveData
{
    public string FileAlarm = "AlarmData.json";

    public void Save<T>(T data)
    {
#if UNITY_ANDROID || UNITY_EDITOR
        string path = Path.Combine(Application.persistentDataPath, FileAlarm);
#else
            string path = Path.Combine(Application.dataPath, fileName);
#endif
        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(path, jsonData);
    }

    public T LoadData<T>()
    {

#if UNITY_ANDROID || UNITY_EDITOR
        string path = Path.Combine(Application.persistentDataPath, FileAlarm);
#else
            string path = Path.Combine(Application.dataPath, fileName);
#endif

        if (!File.Exists(path))
        {
            Debug.Log("No saved data found.");
            return default(T);
        }

        string jsonData = File.ReadAllText(path);

        return JsonUtility.FromJson<T>(jsonData);
    }

    public void DeleteFile(string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("File deleted: " + filePath);
        }
        else
        {
            Debug.Log("File not found: " + filePath);
        }
    }
}
