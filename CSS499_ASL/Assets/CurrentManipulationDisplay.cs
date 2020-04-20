using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentManipulationDisplay : MonoBehaviour
{
    public GameObject MRPlayspace;
    Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Manipulation : T";
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Manipulation : " + MRPlayspace.GetComponent<ArmManipulator>().getTRS();
    }
}
