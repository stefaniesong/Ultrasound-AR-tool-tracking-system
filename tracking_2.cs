using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Matrix transformaiton
public class tracking_2 : MonoBehaviour
{
    //Define two markers
    public GameObject M1;//torso
    public GameObject M2;//probe

    //Define the translation and rotation matrixes of the two markers
    public Vector3 position1;
    public Quaternion rotation1;
    public Vector3 position2;
    public Quaternion rotation2;
    public Pose_position TP;

    public Vector3 Reg_translation;
    public Vector3 Reg_orientation;
    public Vector3 Cal_translation;
    public Vector3 Cal_orientation;
    public Vector3 rela_p;
    public Quaternion rela_r;


    private Matrix4x4 probe_M2;
    private Matrix4x4 phantom_M1;
    private Matrix4x4 matrix_M1;
    private Matrix4x4 matrix_M2;
    private Matrix4x4 probe_phantom;

    // public static string path = "/Users/songguanyu/Desktop";

    void Start()
    {
        Debug.Log("Tracking starts!");
    }

    void Update()
    {
        //Track the translation and rotation matrixes of the two markers


        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A key was pressed");
            position1 = M1.transform.position;
            rotation1 = M1.transform.rotation;
            position2 = M2.transform.position;
            rotation2 = M2.transform.rotation;

            matrix_M1 = M1.transform.localToWorldMatrix;
            matrix_M2 = M2.transform.localToWorldMatrix;
            phantom_M1 = Matrix4x4.identity;
            probe_M2 = Matrix4x4.identity;
            phantom_M1.SetTRS(Reg_translation, Quaternion.Euler(Reg_orientation), new Vector3(1f, 1f, 1f));
            probe_M2.SetTRS(Cal_translation, Quaternion.Euler(Cal_orientation), new Vector3(1f, 1f, 1f));
            probe_phantom = phantom_M1.inverse * matrix_M1.inverse * matrix_M2 * probe_M2;
            rela_r = probe_phantom.rotation;
            rela_p = new Vector3(probe_phantom[0, 3], probe_phantom[1, 3], probe_phantom[2, 3]);
            TP.position = rela_p;
            TP.orientation = rela_r;
            Debug.Log("show:" + rela_p + rela_r);
            // string json = JsonUtility.ToJson(TP);
        
        }


    }
}

