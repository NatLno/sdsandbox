using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public enum MoveType
{
    Joystick,
    Trigger,
    None
}

public class VrInputManager : MonoBehaviour
{
    [SerializeField]
    GameObject XrOrigin;

    [SerializeField]
    InputActionProperty rightHandMoveAction;

    [SerializeField]
    InputActionProperty leftHandTriggerAction;

    [SerializeField]
    InputActionProperty rightHandTriggerAction;

    [SerializeField]
    JoystickCarControl joystickCarControl;

    [SerializeField]
    MoveType moveType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        joystickCarControl = GameObject.FindObjectOfType<JoystickCarControl>();
    }

    private void FixedUpdate()
    {
        if (joystickCarControl != null && moveType != MoveType.None)
        {
            if (moveType == MoveType.Joystick)
            {
                joystickCarControl.Car.RequestSteering(rightHandMoveAction.action.ReadValue<Vector2>().x * joystickCarControl.MaximumSteerAngle);
                joystickCarControl.Car.RequestThrottle(rightHandMoveAction.action.ReadValue<Vector2>().y);
            }
            else if (moveType == MoveType.Trigger)
            {
                joystickCarControl.Car.RequestSteering(rightHandMoveAction.action.ReadValue<Vector2>().x * joystickCarControl.MaximumSteerAngle);
                joystickCarControl.Car.RequestThrottle(leftHandTriggerAction.action.ReadValue<float>() + (rightHandTriggerAction.action.ReadValue<float>() * -1));
            }
        }
    }

    public void SetMoveType(int moveTypeIndex)
    {
        moveType = (MoveType)Enum.Parse(typeof(MoveType), moveTypeIndex.ToString());
    }
}
