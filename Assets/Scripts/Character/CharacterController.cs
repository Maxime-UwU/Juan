using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement m_Movement;

    // Update is called once per frame
    void Update()
    {
        float dir = 0;

        if (Keyboard.current.aKey.isPressed)
        {
            dir = -1;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            dir = 1;
        }

        m_Movement.Move(dir);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            m_Movement.Jump();
        }
    }
}