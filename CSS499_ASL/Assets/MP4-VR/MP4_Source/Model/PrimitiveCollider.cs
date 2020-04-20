using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimitiveCollider : MonoBehaviour
{
    public GameObject primObj;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(primObj != null);
    }

    public GameObject getPrimitive()
    {
        return primObj;
    }

}
