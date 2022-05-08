using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
public class tracking2 : MonoBehaviour
{
    //Define two markers
    public GameObject M1;//torso
    public GameObject M2;//probe

    //Define the translation and rotation matrixes of the two markers
    public Vector3 position1;
    public Quaternion rotation1;
    public Vector3 position2;
    public Quaternion rotation2;


    public Vector3 rela_p;
    public Quaternion rela_r;
    public Pose_position pose_Position1;

    public static int n = 0;

    //Define the camera parameters

    //Camera camera;

    // stores all game locations for saving


    void Start()
    {
        Debug.Log("Tracking starts!");
    }


    //Transform the coordinates to get the relation of the two markers
    void Update()
    {

        // Track the translation and rotation matrixes of the two markers
        // Access to the 3D  world space position of the Transform: https://docs.unity3d.com/ScriptReference/Transform-position.html 
        position1 = M1.transform.position;
        rotation1 = M1.transform.rotation;

        position2 = M2.transform.position;
        rotation2 = M2.transform.rotation;


        //Calculate their relative pose and positions
        rela_p = position1 - position2;
        rela_r = rotation1 * Quaternion.Inverse(rotation2);


        pose_Position1.position = rela_p;
        pose_Position1.orientation = rela_r;

        //Show the estimation matrix
        //Debug.Log("<color=#FFFF00>" + "Position 1 and Rotation 1 is:" + position1 + rotation1 + "!" + "</color>");
        //Debug.Log("<color=#00EEEE>" + "Position 2 and Rotation 2 is:" + position2 + rotation2 + "!" + "</color>");
        //Debug.Log("<color=#FF0066>" + "The relative pose and position is:" + rela_p + rela_r + "!" + "</color>");

        if (Input.GetKeyDown("space"))
        {
            n++;
            Debug.Log("space key was pressed.");
            save.Save(pose_Position1);
            Debug.Log("location" + n);
            Debug.Log("Save the image.");
        }
        
    }

}
