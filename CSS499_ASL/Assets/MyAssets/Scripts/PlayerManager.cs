using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerController controller;
    public ASL.ASLObject Player1;
    public ASL.ASLObject Player2;
    // Start is called before the first frame update
    void Start()
    {
        if(ASL.GameLiftManager.GetInstance().m_PeerId == 1)
        {
            controller.client = Player1;
        }
        if (ASL.GameLiftManager.GetInstance().m_PeerId == 2)
        {
            controller.client = Player2;
        }
    }
}
