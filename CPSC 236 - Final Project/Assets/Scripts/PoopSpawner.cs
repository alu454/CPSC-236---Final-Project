using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopSpawner : RandomTimedObjectPlacer
{

    public override void Start()
    {
        MinimumTimeToCreation = 1;
        MaximumTimeToCreation = 5;
        base.Start();
    }

    public override void Create()
    {
        Instantiate(Prefab, ScreenPositionTools.RandomWorldLocation(Camera), Quaternion.identity);
        base.Create();
    }
}
