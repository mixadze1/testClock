using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesHandler : MonoBehaviour
{
    private SaveData _saveData;

    public void DeleteSaves()
    {
        if (_saveData == null)
            _saveData = new SaveData();

        _saveData.DeleteFile(_saveData.FileAlarm);
    }
}
