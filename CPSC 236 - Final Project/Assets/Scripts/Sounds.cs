using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds Instance;
    public AudioClip GameStartSound;
    public AudioClip GameWinSound;
    public AudioClip GameLoseSound;
    private AudioSource audioSource;

    private void Awake()
    {
       
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;
      
    }

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void PlayGameOver()
    {
        audioSource.PlayOneShot(GameLoseSound);
    }

    public void PlayGameWon()
    {
        audioSource.PlayOneShot(GameWinSound);
    }
    public void PlayStart()
    {
        audioSource.PlayOneShot(GameStartSound);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
