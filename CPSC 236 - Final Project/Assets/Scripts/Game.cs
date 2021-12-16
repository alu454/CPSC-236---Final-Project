using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Wizzy Wizzy;
    public SpriteRenderer bombSpriteRenderer;
    public SpriteRenderer swordSpriteRenderer;
    public SpriteRenderer featherSpriteRenderer;
    public SpriteRenderer poopSpriteRenderer;
    public Corgi Corgi;
    public static Game Instance;
    public Readouts Readouts;
    public bool StopSpawning;
    public GameObject DamagePrefab;

    public Collider bombCollider;
    public Collider featherCollider;
    public Collider swordCollider;
    public Collider poopCollider;

    private int featherCount;
    private Levels Levels;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
        //Levels = gameObject.GetComponent<Levels>();
    }

    private void Start()
    {
        Reset();
    }

    public void CollectFeather()
    {
        UpdateFeatherCount(featherCount + 1);
        Readouts.DisplayCorgiHealth(Corgi.GetHealth());
        CheckIfWonLevel();
    }

    public void CheckGameOverAfterCollision()
    {
        if (Wizzy.CheckIfHealthZero())
            DisableGamePlay();
        if (Corgi.GetHealth() == 0)
            DisableGamePlay();
    }

    public void HitPoop(int health)
    {
        Readouts.DisplayCorgiHealth(health);
    }

    private void UpdateFeatherCount(int count)
    {
        featherCount = count;
        Readouts.ShowFeatherCount(featherCount);
        Readouts.DisplayFeatherCount(featherCount);
    }

    private void CheckIfWonLevel()
    {
        if (featherCount == 3)
            DisableGamePlay();
    }

    public void DamageEffect(GameObject fire)
    {
        Instantiate(DamagePrefab, fire.transform.position, Quaternion.identity);
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
        GameObject[] poop = GameObject.FindGameObjectsWithTag("Poop");
        foreach (GameObject item in poop)
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
        poopSpriteRenderer.enabled = false;

        bombCollider.isTrigger = true;
        featherCollider.isTrigger = true;
        swordCollider.isTrigger = true;
        poopCollider.isTrigger = true;
    }

    public void ShowPrefabs()
    {
        bombSpriteRenderer.enabled = true;
        swordSpriteRenderer.enabled = true;
        featherSpriteRenderer.enabled = true;
        poopSpriteRenderer.enabled = true;

        bombCollider.isTrigger = false;
        featherCollider.isTrigger = false;
        swordCollider.isTrigger = false;
        poopCollider.isTrigger = false;
    }

    private void Reset()
    {
        featherCount = 0;
        Corgi.SetHealth(4); 
        Readouts.Reset(featherCount,Corgi.GetHealth());
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
