using UnityEngine;
using System.IO;

// Save the image the camera captured.
public class capture : MonoBehaviour
{
    public int resWidth = 1920;
    public int resHeight = 1080;
    public static string path = "/Users/songguanyu/Desktop";
    public GameObject C1;
    public int num = 0;

    // Take a "screenshot" of a camera's Render Texture.
    Texture2D RTImage(Camera camera)
    {
        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.
        var currentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;

        // Render the camera's view.
        camera.Render();

        // Make a new texture and read the active Render Texture into it.
        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();

        // Replace the original active Render Texture.
        RenderTexture.active = currentRT;
        return image;
    }

    void captureSlice(int n)
    {
        Camera Cam = C1.GetComponent<Camera>();

        RenderTexture rendertex = new RenderTexture(resWidth, resHeight, 24);
        Cam.targetTexture = rendertex;
        Cam.Render();

        //RenderTexture RT = RenderTexture.active;
        RenderTexture.active = Cam.targetTexture;

        
        //print(Cam.targetTexture);
        // Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
        Texture2D Image = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        // Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
        Image.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        Image.Apply();
        Cam.targetTexture = null;
        RenderTexture.active = null;

        var Bytes = Image.EncodeToPNG();
        File.WriteAllBytes(path + "/test_"+ System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+ ".png", Bytes);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            num++;
            Debug.Log("Save the image." + num);
            captureSlice(num);
        }
    }
}