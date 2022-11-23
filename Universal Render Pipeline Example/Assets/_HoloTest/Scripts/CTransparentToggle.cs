using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CTransparentToggle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyUp( KeyCode.F1 ) )
        {
            Camera mainCam = Camera.main;
            
            if( mainCam.clearFlags != CameraClearFlags.Skybox )
            {
                mainCam.allowHDR = true;
                mainCam.clearFlags = CameraClearFlags.Skybox;
                mainCam.GetComponent< UniversalAdditionalCameraData >().renderPostProcessing = true;
            }
            else if( mainCam.clearFlags != CameraClearFlags.SolidColor )
            {
                mainCam.allowHDR = false;
                mainCam.GetComponent< UniversalAdditionalCameraData >().renderPostProcessing = false;
                mainCam.clearFlags = CameraClearFlags.SolidColor;
                mainCam.backgroundColor = new Color( 0, 0, 0, 0 );
            }
        }
    }
}
