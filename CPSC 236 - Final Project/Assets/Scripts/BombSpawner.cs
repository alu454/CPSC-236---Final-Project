using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : RandomTimedObjectPlacer
{
   

    public override void Start()
    {
        MinimumTimeToCreation = 10;
        MaximumTimeToCreation = 10;

        base.Start();
    }

    public override void Create()
    {
        Instantiate(Prefab, new Vector3(-1, 1, 0), Quaternion.identity);
        base.Create();
    }
}
