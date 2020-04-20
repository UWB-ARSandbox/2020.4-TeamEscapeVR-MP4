using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRaycastCameraFinder : MonoBehaviour
{
    private GameObject UIRaycastCam;
    private bool added = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!added)
        {
            if (UIRaycastCam == null)
            {
                UIRaycastCam = GameObject.Find("UIRaycastCamera");
            }
            else
            {
                DontDestroyOnLoad(UIRaycastCam);
                added = true;
            }
        }
    }
}
