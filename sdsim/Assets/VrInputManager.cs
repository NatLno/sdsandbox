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
    InputActionProperty headRotation;

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
        // pass the input to the car!
        //float h = CrossPlatformInputManager.GetAxis("Horizontal");
        //float v = CrossPlatformInputManager.GetAxis("Vertical");
        //float b = CrossPlatformInputManager.GetAxis("Jump");
        //float handbrake = CrossPlatformInputManager.GetAxis("Jump");
        if (joystickCarControl != null)
        {
            if (moveType == MoveType.Joystick)
            {
                joystickCarControl.Car.RequestSteering(rightHandMoveAction.action.ReadValue<Vector2>().x * joystickCarControl.MaximumSteerAngle);
                joystickCarControl.Car.RequestThrottle(rightHandMoveAction.action.ReadValue<Vector2>().y);
            }
            else if (moveType == MoveType.Trigger)
            {
                joystickCarControl.Car.RequestSteering(headRotation.action.ReadValue<Quaternion>().eulerAngles.y * joystickCarControl.MaximumSteerAngle);
                joystickCarControl.Car.RequestThrottle((leftHandTriggerAction.action.ReadValue<float>() + rightHandTriggerAction.action.ReadValue<float>()) / 2);
            }
        }
        //car.RequestFootBrake(b);
        //car.RequestHandBrake(handbrake);
    }
}
