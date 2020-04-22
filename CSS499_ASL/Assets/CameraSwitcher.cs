using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject secondCam;

    public void Start()
    {
        mainCam.GetComponent<Camera>().targetDisplay = 0;
        secondCam.GetComponent<Camera>().targetDisplay = 1;
    }

    public void switchCam()
    {
        if(mainCam.transform.tag == "MainCamera")
        {
            var temp = secondCam;
            secondCam = mainCam;
            mainCam = temp;
            mainCam.transform.tag = "MainCamera";
            secondCam.transform.tag = "Untagged";
            mainCam.GetComponent<Camera>().targetDisplay = 0;
            secondCam.GetComponent<Camera>().targetDisplay = 1;
        }
    }
}
