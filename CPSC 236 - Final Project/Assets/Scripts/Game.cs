using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Wizzy Wizzy;
    public SpriteRenderer bombSpriteRenderer;
    public SpriteRenderer swordSpriteRenderer;
    public SpriteRenderer featherSpriteRenderer;
    public Corgi Corgi;
    public static Game Instance;
    public Readouts Readouts;
    public bool StopSpawning;

    public Collider bombCollider;
    public Collider featherCollider;
    public Collider swordCollider;

    private int featherCount;


    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
        
    }

    private void Start()
    {
        Reset();
    }

    public void CollectFeather()
    {
        UpdateFeatherCount(featherCount + 1);
        CheckIfWonLevel();
    }

    public void CheckGameOverAfterCollision()
    {
        if (Wizzy.CheckIfHealthZero())
            DisableGamePlay();
    }

    private void UpdateFeatherCount(int count)
    {
        featherCount = count;
        Readouts.ShowFeatherCount(featherCount);
    }

    private void CheckIfWonLevel()
    {
        if (featherCount == 3)
            DisableGamePlay();
    }



    private void DisableGamePlay()
    {
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject item in bombs)
        {
            Destroy(item);
        }
        GameObject[] feathers = GameObject.FindGameObjectsWithTag("Feather");
        foreach (GameObject item in feathers)
        {
            Destroy(item);
        }
        GameObject[] swords = GameObject.FindGameObjectsWithTag("Sword");
        foreach (GameObject item in swords)
        {
            Destroy(item);
        }
        HidePrefabs();
        Corgi.Disable();
        
    }

    public void HidePrefabs()
    {
        bombSpriteRenderer.enabled = false; 
        swordSpriteRenderer.enabled = false;
        featherSpriteRenderer.enabled = false;

        bombCollider.isTrigger = true;
        featherCollider.isTrigger = true;
        swordCollider.isTrigger = true;
    }

    public void ShowPrefabs()
    {
        bombSpriteRenderer.enabled = true;
        swordSpriteRenderer.enabled = true;
        featherSpriteRenderer.enabled = true;

        bombCollider.isTrigger = false;
        featherCollider.isTrigger = false;
        swordCollider.isTrigger = false;
    }

    private void Reset()
    {
        featherCount = 0;
        Readouts.Reset(featherCount);
        ShowPrefabs();
        Corgi.Reset();
    }

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
