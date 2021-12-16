using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;
    
    public Camera Camera;
    public int MinimumTimeToCreation = 1;
    public int MaximumTimeToCreation = 3;

    private bool isWaitingToCreate = false;
    private int secondsUntilCreation;

    public virtual void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (!isWaitingToCreate)
        {
            isWaitingToCreate = true;
            secondsUntilCreation = Random.Range(MinimumTimeToCreation, MaximumTimeToCreation + 1);
            StartCoroutine(CountdownUntilCreation());
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        yield return new WaitForSeconds(secondsUntilCreation);
        
        Create();
    }

    public virtual void Create()
    {
        isWaitingToCreate = false;
        
    }
}
