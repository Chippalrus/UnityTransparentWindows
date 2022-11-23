using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
public class CTransparentToggle : MonoBehaviour
{
[SerializeField]
    private VolumeProfile m_ppVol = null;
    private ColorAdjustments m_ColorAdjustments;
[SerializeField]
    private GameObject  m_RetainFilter = null;
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
            HDAdditionalCameraData hdSettings = mainCam.GetComponent< HDAdditionalCameraData >();
            if( m_ppVol != null )
            {
                m_ppVol.TryGet< ColorAdjustments >( out m_ColorAdjustments );
            }
            
            if( hdSettings.clearColorMode == HDAdditionalCameraData.ClearColorMode.Color )
            {
                Debug.Log("Sky");
                hdSettings.clearColorMode = HDAdditionalCameraData.ClearColorMode.Sky;
                m_ColorAdjustments.active = false;
                if( m_RetainFilter != null ){ m_RetainFilter.SetActive( false ); }
            }
            else if( hdSettings.clearColorMode == HDAdditionalCameraData.ClearColorMode.Sky )
            {
                Debug.Log("Colour");
                hdSettings.clearColorMode = HDAdditionalCameraData.ClearColorMode.Color;
                hdSettings.backgroundColorHDR = new Color( 0, 0, 0, 0 );
                m_ColorAdjustments.active = true;
                if( m_RetainFilter != null ){ m_RetainFilter.SetActive( true ); }
            }
        }
    }
}
