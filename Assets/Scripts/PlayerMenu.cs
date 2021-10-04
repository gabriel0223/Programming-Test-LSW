using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    private PlayerController playerControlller;

    private void Awake()
    {
        playerControlller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPlayerMenu()
    {
        gameObject.SetActive(true);
        AudioManager.instance.Play("Pop01");
        playerControlller.LockInput(true);
    }
    
    public void ClosePlayerMenu()
    {
        AudioManager.instance.Play("ClickBack");
        playerControlller.LockInput(false);
        gameObject.SetActive(false);
    }
}
