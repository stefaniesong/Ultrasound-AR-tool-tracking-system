using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

public class save : MonoBehaviour
{
   // DateTime dt = DateTime.Now;
   // dt.ToString();
    public static string directory = "/SaveData/";
    public static string fileName = "relative position and orientation" + ".JSON";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void Save(Pose_position toolPose)
    {
        string dir = Application.persistentDataPath + directory;
        Debug.Log(dir);

        string json = JsonUtility.ToJson(toolPose);

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
            File.WriteAllText(dir + fileName, json);
            Console.WriteLine("file path:\t ", dir + fileName);
        }
        else
        {
            using (StreamWriter sw = File.AppendText(dir + fileName))
            {
                sw.WriteLine(json);
            }
        }

        Console.WriteLine("file path:{0}\t ", dir + fileName);
    }

    // Update is called once per frame
    void Update()
    {

    }

}

