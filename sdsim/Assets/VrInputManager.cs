using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class VrInputManager : MonoBehaviour
{
    [SerializeField]
    GameObject XrOrigin;

    [SerializeField]
    InputActionProperty leftHandMoveAction;

    private void OnEnable()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        var leftHandValue = leftHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(leftHandMoveAction.action.ReadValue<Vector2>() * Time.deltaTime);
    }
}
