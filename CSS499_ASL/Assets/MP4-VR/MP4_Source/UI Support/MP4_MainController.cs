using System; // for assert
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for GUI elements: Button, Toggle

public partial class MP4_MainController : MonoBehaviour
{

    // reference to all UI elements in the Canvas
    public MP4_World mModel = null;
    public SceneNodeControl SNControl = null;
    public PositionControl LookAtControl = null;


    // Use this for initialization
    void Start()
    {
        Debug.Assert(mModel != null);
        Debug.Assert(SNControl != null);
        Debug.Assert(LookAtControl != null);
    }

}
