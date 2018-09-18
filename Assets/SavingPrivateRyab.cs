using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SavingPrivateRyab : MonoBehaviour
{
    public int currentlevels;

    private void Awake()
    {
        LoadDate();
    }

    private void LoadDate()
    {
        if (File.Exists(Application.persistentDataPath + "/Levelinfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Levelinfo.dat", FileMode.Open);
            PlayerInfo PI = (PlayerInfo)bf.Deserialize(file);
            file.Close();
            currentlevels = PI.levels;
        }
    }
}