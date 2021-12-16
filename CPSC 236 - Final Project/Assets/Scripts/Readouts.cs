using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Readouts : MonoBehaviour
{
    public Text Level;
    public Text FeatherCount;

    public void Reset(int startingNumFeathers)
    {
        ShowLevel(1);
        ShowFeatherCount(startingNumFeathers);

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
}
