using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ASL.ASLObject client;
    public int speed = 1;

    // Update is called once per frame
    void Update()
    {
        Vector3 wasd = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//        client.transform.position += wasd * speed * Time.deltaTime;

        client.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
        {
            client.GetComponent<ASL.ASLObject>().SendAndIncrementWorldPosition(wasd * speed * Time.deltaTime);
        });
    }
}
