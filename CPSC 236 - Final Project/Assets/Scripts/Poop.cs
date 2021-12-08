using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : TimedLifespan
{
    
    public override void Start()
    {
        SecondsOnScreen = 5;
        base.Start();
    }

    
}
