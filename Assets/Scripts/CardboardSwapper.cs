using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class CardboardSwapper : MonoBehaviour 
{
    [SerializeField]
    private GameObject reticleObject;
    
	[SerializeField]
    private GameObject worldCanvas;
    
    [SerializeField]
    private GameObject NonVRInputSystem;

    void Awake()
    {        
        // print(XRSettings.loadedDeviceName);
        SwitchToVRInputMode(true);
    }

    public void ToggleVR()
    {
        if (XRSettings.loadedDeviceName == "cardboard") 
        {        
            // print("cmode");
            StartCoroutine(SwitchTo2D());
        } else 
        {       
            // print("2dmode");
            StartCoroutine(SwitchToVR());
        }
    }

    IEnumerator SwitchToVR() 
    {
        string desiredDevice = "cardboard";

        // Disable auto rotation, except for landscape left.
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        while (Screen.orientation != ScreenOrientation.LandscapeLeft 
        && Screen.orientation != ScreenOrientation.LandscapeRight) 
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            yield return null;
        }

        if (String.Compare(XRSettings.loadedDeviceName, desiredDevice, true) != 0) 
        {
            XRSettings.LoadDeviceByName(desiredDevice);
            yield return null;
        }

        XRSettings.enabled = true;
        SwitchToVRInputMode(true);
    }

    // Resets camera transform and settings on all enabled eye cameras.
    private void ResetCameras() 
    {
        for (int i = 0; i < Camera.allCameras.Length; i++) 
        {
            Camera cam = Camera.allCameras[i];
            if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None) 
            {
                cam.transform.localPosition = Vector3.zero;
                cam.transform.localRotation = Quaternion.identity;
            }
        }
    }

    private void SwitchToVRInputMode(bool enableVRInput)
    {
        worldCanvas.GetComponent<GvrPointerGraphicRaycaster>().enabled = enableVRInput;
        worldCanvas.GetComponent<GraphicRaycaster>().enabled = !enableVRInput;
        NonVRInputSystem.SetActive(!enableVRInput);
    }

    IEnumerator SwitchTo2D() 
    {
        XRSettings.LoadDeviceByName("");
        yield return null;
        ResetCameras();
        XRSettings.enabled = false;
        SwitchToVRInputMode(false);
    }
}