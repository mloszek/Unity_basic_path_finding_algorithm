using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveLoadScript
{
    public static void Save()
    {
        File.WriteAllText(Application.persistentDataPath + "\\save.crp", MapGenerator.SaveMap());
    }

    public static string Load()
    {
        return File.ReadAllText(Application.persistentDataPath + "\\save.crp");
    }
}
