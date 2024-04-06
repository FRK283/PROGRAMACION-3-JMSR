
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Eb este script, usaremos las configuraciones de inputs 
///para realizar acciones
/// </summary>
public class InputHandler : MonoBehaviour
{
   [SerializeField] private InputConfig actualConfig;
    private static InputConfig _actualConfig;


    private void OnValidate()
    {
        _actualConfig = actualConfig;
    }

    public static bool MoveForwardInput()
    {
        return Input.GetKey(_actualConfig.walkForward);
    }

    public static bool MoveBackwardInput()
    {
        return Input.GetKey(_actualConfig.walkBackward);
    }

    public static bool RotateLeftInput()
    {
        return Input.GetKey(_actualConfig.rotateLeft);
    }

    public static bool RotateRightInput()
    {
        return Input.GetKey(_actualConfig.rotateRight);
    }

    public static bool JumpInput()
    {
        return Input.GetKeyDown(_actualConfig.jumpKey);
    }

    public static bool RunInput()
    {
        return Input.GetKey(_actualConfig.runKey);
    }

    public static bool AimInput()
    {
        return Input.GetKeyDown(_actualConfig.AimKey);
    }

    public static bool ShootKey()
    {
        return Input.GetKeyDown(_actualConfig.shootKey);
    }

    public static bool Reload()
    {
        return Input.GetKeyDown(_actualConfig.reloadKey);
    }

    public static int Scroll()
    {
        float input = Input.GetAxis("Mouse ScrollWheel");
        return input == 0 ? 0 : input > 0 ? 1 : -1;
    }
 

}
