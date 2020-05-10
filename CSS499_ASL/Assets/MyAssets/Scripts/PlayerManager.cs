using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject Player1;
    public GameObject Player2;
    // Start is called before the first frame update
    void Start()
    {
        if(ASL.GameLiftManager.GetInstance().m_PeerId == 1)
        {
            Player1.transform.position = playerCamera.transform.position;
            Player1.transform.rotation = playerCamera.transform.rotation;
            Player1.transform.parent = playerCamera.transform;
        }
        if (ASL.GameLiftManager.GetInstance().m_PeerId == 2)
        {
            Player2.transform.position = playerCamera.transform.position;
            Player2.transform.rotation = playerCamera.transform.rotation;
            Player2.transform.parent = playerCamera.transform;
        }
    }

    void Update()
    {
        if (ASL.GameLiftManager.GetInstance().m_PeerId == 1)
        {
            Player1.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
             {
                 Player1.GetComponent<ASL.ASLObject>().SendAndSetWorldPosition(playerCamera.transform.position);
             });

            Player1.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
            {
                Player1.GetComponent<ASL.ASLObject>().SendAndSetWorldRotation(new Quaternion(playerCamera.transform.eulerAngles.x, playerCamera.transform.eulerAngles.y, playerCamera.transform.eulerAngles.z, 1));
            });
        }
        if (ASL.GameLiftManager.GetInstance().m_PeerId == 2)
        {
            Player2.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
            {
                Player2.GetComponent<ASL.ASLObject>().SendAndSetWorldPosition(playerCamera.transform.position);
            });

            Player2.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
            {
                Player2.GetComponent<ASL.ASLObject>().SendAndSetWorldRotation(new Quaternion(playerCamera.transform.eulerAngles.x, playerCamera.transform.eulerAngles.y, playerCamera.transform.eulerAngles.z, 1));
            });
        }
    }
}
