using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [Header("List of dialogues with this NPC")]
    [SerializeField] private List<SO_Dialogue> dialogueList = new List<SO_Dialogue>();

    private IInteractable _interactableImplementation;
    private Transform npcSprite;
    private PlayerController player;

    private void Awake()
    {
        npcSprite = GetComponentInChildren<Animator>().transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        //if the NPC is looking the other way, flip it 
        var npcScale = npcSprite.localScale;
        
        if ((int)npcSprite.localScale.x == player.directionFacing)
            npcSprite.localScale = new Vector3(-npcScale.x, npcScale.y, npcScale.z);
        
        InteractionManager.instance.StartDialogue(dialogueList[0]);
    }
}
