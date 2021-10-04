using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerMenu playerMenu;

    private void Awake()
    {
        playerMenu = FindObjectOfType<UIManager>().playerMenu;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (playerMenu.gameObject.activeSelf)
                playerMenu.ClosePlayerMenu();
            else
                playerMenu.OpenPlayerMenu();
        }
    }
}
