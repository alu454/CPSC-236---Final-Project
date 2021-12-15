using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float Speed = 1;
    
    void Update()
    {
        gameObject.transform.Translate(0, Speed * Time.deltaTime, 0);
    }
}
