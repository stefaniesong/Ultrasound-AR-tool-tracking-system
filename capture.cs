using UnityEngine;
using System.IO;
// Save the image the camera captured.

public class capture : MonoBehaviour
{
    public static string path = "/Users/songguanyu/Desktop";
    public GameObject M1;
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
        Camera Cam = M1.GetComponent<Camera>();

        RenderTexture RT = RenderTexture.active;
        RenderTexture.active = Cam.targetTexture;

        Cam.Render();

        Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
        Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
        Image.Apply();
        RenderTexture.active = RT;

        var Bytes = Image.EncodeToPNG();
        File.WriteAllBytes(path + "/test_" + n + ".png", Bytes);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Save the image." + num);
            num++;
            captureSlice(num);
        }
    }
}
