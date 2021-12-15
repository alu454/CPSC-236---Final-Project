using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Corgi.MoveWithKeyboard(new Vector2(0, 1));
        }
        if(Input.GetKey(KeyCode.A))
        {
            Corgi.MoveWithKeyboard(new Vector2(-1, 0));
        }
        if(Input.GetKey(KeyCode.S))
        {
            Corgi.MoveWithKeyboard(new Vector2(0, -1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Corgi.MoveWithKeyboard(new Vector2(1, 0));
        }
    }
}
