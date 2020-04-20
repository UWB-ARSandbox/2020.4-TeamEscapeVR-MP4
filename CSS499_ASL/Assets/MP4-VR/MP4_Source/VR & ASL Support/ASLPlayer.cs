using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASLPlayer : MonoBehaviour
{

    public Camera FirstPersonView;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
        {
            this.GetComponent<ASL.ASLObject>().SendAndSetWorldPosition(FirstPersonView.transform.position);
        });
    }
}
