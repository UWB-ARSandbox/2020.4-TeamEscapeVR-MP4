using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += this.transform.forward *  1.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position -= this.transform.right * 1.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= this.transform.forward * 1.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += this.transform.right * 1.0f * Time.deltaTime;
        }
//            Vector3 wasd = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        

        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (var n = 0; n < 90; n++)
            {
                transform.Rotate(0, -30 * Time.deltaTime, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (var m = 0; m < 90; m++)
            {
                transform.Rotate(0, 30 * Time.deltaTime, 0);
            }
        }

    }
}
