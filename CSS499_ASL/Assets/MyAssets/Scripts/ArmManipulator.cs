using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class ArmManipulator : MonoBehaviour
{
    enum Manipulation
    {
        T,R,S
    }

    public bool up;
    public bool down;
    public float x = 0.0f;
    public float z = 0.0f;
    public float y = 0.0f;
    public float limit = 20.0f;
    public GameObject previousObject;
    public GameObject selectedObject;
    public GameObject objectCollider;
    public GameObject cam;

    private Manipulation currentManipulation = Manipulation.T;

    public void Update()
    {
        if(up == down)
        {
            y = 0.0f;
        }

        else if(up)
        {
            y = 1.0f;
        }

        else if(down)
        {
            y = -1.0f;
        }

        if (selectedObject.transform.position.x < limit || selectedObject.transform.position.x > -limit)
        {
            if(currentManipulation == Manipulation.T)
            {
                //selectedObject.transform.position += new Vector3(x * Time.deltaTime, 0, 0);
                selectedObject.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
                {
                    selectedObject.GetComponent<ASL.ASLObject>().SendAndIncrementWorldPosition(new Vector3(x * Time.deltaTime, 0, 0));
                });
            }
            else if(currentManipulation == Manipulation.R)
            {
                //selectedObject.transform.localScale += new Vector3(x * Time.deltaTime, 0, 0);
                selectedObject.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
                {
                    selectedObject.GetComponent<ASL.ASLObject>().SendAndIncrementWorldScale(new Vector3(x * Time.deltaTime, 0, 0));
                });
            }
            else if(currentManipulation == Manipulation.S)
            {
                //selectedObject.transform.Rotate(x, 0, 0);
                selectedObject.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
                {
                    selectedObject.GetComponent<ASL.ASLObject>().SendAndIncrementWorldRotation(new Quaternion(x * Time.deltaTime, 0, 0, 1));
                });
            }
            
        }

        if (selectedObject.transform.position.z < limit || selectedObject.transform.position.z > -limit)
        {
            if (currentManipulation == Manipulation.T)
            {
                //selectedObject.transform.position += new Vector3(0, 0, z * Time.deltaTime);
                selectedObject.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
                {
                    selectedObject.GetComponent<ASL.ASLObject>().SendAndIncrementWorldPosition(new Vector3(0, 0, z * Time.deltaTime));
                });
            }
            else if (currentManipulation == Manipulation.R)
            {
                //selectedObject.transform.localScale += new Vector3(0, 0, z * Time.deltaTime);
                selectedObject.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
                {
                    selectedObject.GetComponent<ASL.ASLObject>().SendAndIncrementWorldScale(new Vector3(0, 0, z * Time.deltaTime));
                });
            }
            else if (currentManipulation == Manipulation.S)
            {
                //selectedObject.transform.Rotate(0, 0, z);
                selectedObject.GetComponent<ASL.ASLObject>().SendAndSetClaim(() =>
                {
                    selectedObject.GetComponent<ASL.ASLObject>().SendAndIncrementWorldRotation(new Quaternion(0, 0, z * Time.deltaTime, 1));
                });
            }
            
        }

        if (selectedObject.transform.position.y < limit || selectedObject.transform.position.y > -limit)
        {
            if (currentManipulation == Manipulation.T)
            {
                selectedObject.transform.position += new Vector3(0, y * Time.deltaTime, 0);
            }
            else if (currentManipulation == Manipulation.R)
            {
                selectedObject.transform.localScale += new Vector3(0, y * Time.deltaTime, 0);
            }
            else if (currentManipulation == Manipulation.S)
            {
                selectedObject.transform.Rotate(0, y, 0);
            }

        }

        ////if (objectCollider.transform.position.x < limit || objectCollider.transform.position.x > -limit)
        //{
        //    objectCollider.transform.position += new Vector3(x * Time.deltaTime, 0, 0);
        //}

        ////if (objectCollider.transform.position.z < limit || objectCollider.transform.position.z > -limit)
        //{
        //    objectCollider.transform.position += new Vector3(0, 0, z * Time.deltaTime);
        //}
    }

    public void setSelectedObject()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 20.0f, Physics.DefaultRaycastLayers));
        {
            if (hit.transform.tag == "MP4MovableObjects")
            {
                previousObject = selectedObject;
                selectedObject = hit.transform.gameObject.GetComponent<PrimitiveCollider>().primObj;
                if (selectedObject == previousObject)
                {
                    selectedObject = selectedObject.transform.parent.parent.gameObject;
                }
            }
        }
    }

    public void setTRS()
    {
        if(currentManipulation == Manipulation.T)
        {
            currentManipulation = Manipulation.R;
        }
        else if(currentManipulation == Manipulation.R)
        {
            currentManipulation = Manipulation.S;
        }
        else
        {
            currentManipulation = Manipulation.T;
        }
    }

    public string getTRS()
    {
        if (currentManipulation == Manipulation.T)
        {
            return "Translation";
        }
        else if (currentManipulation == Manipulation.R)
        {
            return "Rotation";
        }
        else
        {
            return "Scale";
        }
    }

    public void setLeft()
    {
        up = !up;
    }
    public void setRight()
    {
        down = !down;
    }
}
