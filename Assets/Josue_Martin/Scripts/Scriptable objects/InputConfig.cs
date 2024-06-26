using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;


[CreateAssetMenu(fileName = "New Input Config", menuName = "Input/New Input Cofig", order = 0)]
public class InputConfig : ScriptableObject
{

    public KeyCode walkForward = KeyCode.W;
    public KeyCode walkBackward = KeyCode.S;

    public KeyCode rotateLeft = KeyCode.A;
    public KeyCode rotateRight = KeyCode.D;

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode runKey = KeyCode.LeftShift;

    public KeyCode shootKey = KeyCode.Mouse0;
    public KeyCode reloadKey = KeyCode.R;

    public KeyCode AimKey = KeyCode.Mouse1;

}