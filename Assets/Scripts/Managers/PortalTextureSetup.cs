using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraA;
    public Material cameraAMat;
    public Camera cameraB;
    public Material cameraBMat;
    // Start is called before the first frame update
    void Start()
    {
        if (cameraA.targetTexture != null)
        {
            cameraA.targetTexture.Release();
        }
        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraAMat.mainTexture = cameraA.targetTexture;

        if (cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraBMat.mainTexture = cameraB.targetTexture;
    }


}
