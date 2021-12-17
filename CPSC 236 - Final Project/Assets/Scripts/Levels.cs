using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public List<GameObject> levels;
    public Readouts Readouts;

    private int currentLevel = 0;
    private GameObject levelGameObject;

    void Start()
    {
        levelGameObject = CreateLevel();
        UpdateLevelReadout();
    }

    public void GoToNextLevel()
    {
        currentLevel++;
        if (IsGameOver())
            return;
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        if (levelGameObject != null)
            Destroy(levelGameObject);

        levelGameObject = CreateLevel();
        UpdateLevelReadout();
    }

    public bool IsGameOver()
    {
        if (currentLevel == levels.Count)
            return true;
        return false;
    }

    private void UpdateLevelReadout()
    {
        Readouts.ShowLevel(currentLevel + 1);
    }

    private GameObject CreateLevel()
    {
        return Instantiate(levels[currentLevel],
            levels[currentLevel].transform.position,
            Quaternion.identity);
    }
}
