using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawner : RandomTimedObjectPlacer
{
    public override void Start()
    {
        MinimumTimeToCreation = 5;
        MaximumTimeToCreation = 5;
        base.Start();
    }

    public override void Create()
    {
        Instantiate(Prefab, new Vector3(Random.Range(-1, 5), Random.Range(-2, 4), 0), Quaternion.identity);
        base.Create();
    }
}
