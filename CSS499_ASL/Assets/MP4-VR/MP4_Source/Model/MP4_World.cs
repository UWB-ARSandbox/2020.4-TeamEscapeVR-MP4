using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MP4_World : MonoBehaviour
{

    public SceneNode RootNode;
    private float kSightLength = 20f;
    private float kNodeCamPos = 3f;

    // Use this for initialization
    void Start()
    {
        Debug.Assert(RootNode != null);
    }

    void Update()
    {
        Vector3 pos, dir;
        Matrix4x4 m = Matrix4x4.identity;
        RootNode.CompositeXform(ref m, out pos, out dir);

        Vector3 p1 = pos;
        Vector3 p2 = pos + kSightLength * dir;
    }

    public SceneNode GetRootNode() { return RootNode; }

}
