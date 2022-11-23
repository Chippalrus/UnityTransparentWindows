using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class CTransparentToggle : MonoBehaviour
{
[SerializeField]
    private     GameObject  m_TestObject = null;
[SerializeField]
    private     PostProcessVolume  m_ppVol = null;
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
            mainCam.allowHDR = !mainCam.allowHDR;
            ColorGrading colorGrading = null;
            if( m_ppVol != null )
            {
                colorGrading = m_ppVol.profile.GetSetting< ColorGrading >();
            }
            
            if( mainCam.clearFlags != CameraClearFlags.Skybox )
            {
                mainCam.clearFlags = CameraClearFlags.Skybox;
                if( colorGrading != null ) { colorGrading.active = false; }
                m_TestObject.SetActive( false );
            }
            else if( mainCam.clearFlags != CameraClearFlags.SolidColor )
            {
                mainCam.clearFlags = CameraClearFlags.SolidColor;
                mainCam.backgroundColor = new Color( 0, 0, 0, 0 );
                if( colorGrading != null ) { colorGrading.active = true; }
                m_TestObject.SetActive( true );
            }
        }

        if( Input.GetKeyUp( KeyCode.F2 ) )
        {
            if( m_TestObject != null )
            {
                m_TestObject.SetActive( !m_TestObject.activeInHierarchy );
            }
        }
    }
}
