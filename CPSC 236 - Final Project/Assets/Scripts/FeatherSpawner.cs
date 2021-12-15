using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherSpawner : RandomTimedObjectPlacer
{
    public override void Start()
    {
        MinimumTimeToCreation = 15;
        MaximumTimeToCreation = 30;
        base.Start();
    }

    public override void Create()
    {
        Instantiate(Prefab, new Vector3(Random.Range(-1, 5), Random.Range(-2, 4), 0), Quaternion.identity);
        base.Create();
    }
}
