using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Readouts : MonoBehaviour
{
    public Text Level;
    public Text FeatherCount;
    public GameObject FeatherUIEffect;
    public List<GameObject> HeartList;
    public List<GameObject> FeatherList;

    public void Reset(int startingNumFeathers, int startingNumHealth)
    {
        ShowLevel(1);
        ShowFeatherCount(startingNumFeathers);
        DisplayFeatherCount(startingNumFeathers);
        DisplayCorgiHealth(startingNumHealth);
    }

    public void ShowLevel(int level)
    {
        if (level < 0)
            level = 0;
        Level.text = "Level: " + level;
    }

    public void ShowFeatherCount(int featherCount)
    {
        if (featherCount < 0)
            featherCount = 0;
        FeatherCount.text = featherCount.ToString();
    }

    public void DisplayCorgiHealth(int healthCount)
    {
        int count = 1;
        foreach (GameObject heart in HeartList)
        {
            if (count <= healthCount)
                heart.SetActive(true);
            else
                heart.SetActive(false);
            count = count + 1;
        }
    }

    public void DisplayFeatherCount(int featherCount)
    {
        int count = 1;
        foreach (GameObject feather in FeatherList)
        {
            if (count < featherCount)
                feather.SetActive(true);
            else if (count == featherCount)
            {
                feather.SetActive(true);
                Instantiate(FeatherUIEffect, feather.transform.position, Quaternion.identity);
            }
            else
                feather.SetActive(false);
            count = count + 1;
        }
    }
}
