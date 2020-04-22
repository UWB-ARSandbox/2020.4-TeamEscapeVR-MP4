using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class InputController : InputSystemGlobalListener, IMixedRealityInputHandler<Vector2>, IMixedRealityInputHandler
{
    public MixedRealityInputAction locomotion;
    public MixedRealityInputAction armManipulator;
    public MixedRealityInputAction selectObject;
    public MixedRealityInputAction TRSSwitch;
    public MixedRealityInputAction leftGrip;
    public MixedRealityInputAction rightGrip;
    public MixedRealityInputAction cameraSwitch;
    public Locomotion controller;
    public ArmManipulator arms;
    public CameraSwitcher camSwitcher;
    public float deadZone = .4f;

    public void OnInputChanged(InputEventData<Vector2> eventData)
    {
        if (eventData.MixedRealityInputAction == locomotion)
        {
            float x = eventData.InputData.x;
            float z = eventData.InputData.y;
            if (x < deadZone && x > -deadZone)
            {
                x = 0;
            }
            if (z < deadZone && z > -deadZone)
            {
                z = 0;
            }
            controller.x = x;
            controller.z = z;
        }

        if (eventData.MixedRealityInputAction == armManipulator)
        {
            float x = eventData.InputData.x;
            float z = eventData.InputData.y;
            if (x < deadZone && x > -deadZone)
            {
                x = 0;
            }
            if (z < deadZone && z > -deadZone)
            {
                z = 0;
            }
            arms.x = x;
            arms.z = z;
        }

        
    }

    public void OnInputDown(InputEventData eventData)
    {
        if (eventData.MixedRealityInputAction == selectObject)
        {
            UnityEngine.Debug.Log("called 1");
            arms.setSelectedObject();
        }

        if (eventData.MixedRealityInputAction == TRSSwitch)
        {
            arms.setTRS();
        }

        if(eventData.MixedRealityInputAction == cameraSwitch)
        {
            camSwitcher.switchCam();
        }

        if (eventData.MixedRealityInputAction == leftGrip)
        {
            arms.setLeft();
        }
        if (eventData.MixedRealityInputAction == rightGrip)
        {
            arms.setRight();
        }
    }

    public void OnInputUp(InputEventData eventData)
    {
        if (eventData.MixedRealityInputAction == leftGrip)
        {
            arms.setLeft();
        }
        if (eventData.MixedRealityInputAction == rightGrip)
        {
            arms.setRight();
        }
    }
}
