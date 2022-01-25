using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager : Singleton<SaveLoadManager>
{
    public void Save(string foldername, string filename, string data)
    {
        string directory = Application.persistentDataPath + "/" + foldername;
        string file = directory + "/" + filename;
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        File.WriteAllText(file, data);
    }
    public void Load(string foldername, string filename, Action<string> callback)
    {
        string directory = Application.persistentDataPath + "/" + foldername;
        string file = directory + "/" + filename;

        string data = "";
        if (File.Exists(file))
        {
            data = File.ReadAllText(file);
            Debug.Log(data);
        }
        callback?.Invoke(data);
    }
    public void DeleteFolder(string foldername, Action callback)
    {
        string directory = Application.persistentDataPath + "/" + foldername;
        if (Directory.Exists(directory)) //If this folder exists, delete it
        {
            foreach (string d in Directory.GetFileSystemEntries(directory))
            {
                if (File.Exists(d))
                    File.Delete(d); //Delete the file directly                       
                else
                    DeleteFolder(d, callback); //Recursively delete subfolders
            }
            Directory.Delete(directory); //Delete an empty folder                
        }
        callback?.Invoke();
    }
}
