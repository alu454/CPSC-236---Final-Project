using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLifespan : MonoBehaviour
{
    public int SecondsOnScreen;
    public virtual void Start()
    {
        StartCoroutine(CountdownTillDeath());
    }
    IEnumerator CountdownTillDeath()
    {
        yield return new WaitForSeconds(SecondsOnScreen);
        Destroy(gameObject);
    }
}
