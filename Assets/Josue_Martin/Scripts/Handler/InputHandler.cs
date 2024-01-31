using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private InputConfig inputConfig;
    private static InputConfig _actualConfig;

    private void Start()
    {
       
    }


    private void OnValidate()
    {
       _actualConfig = actualConfig;  
    }


    public static bool JumpInput()
    {
        return Input.GetKeyDown(_actualConfig.jumpKey);

    }

}


