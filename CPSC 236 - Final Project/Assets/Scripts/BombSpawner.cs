using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : RandomTimedObjectPlacer
{
    public override void Start()
    {
        MinimumTimeToCreation = 4;
        MaximumTimeToCreation = 4;
        base.Start();
    }

    public override void Create()
    {
        Instantiate(Prefab, ScreenPositionTools.RandomWorldLocation(Camera), Quaternion.identity);
        base.Create();
    }
}
