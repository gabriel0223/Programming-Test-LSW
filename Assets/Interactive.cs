using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour, IInteractable
{
    [Tooltip("The dialogue that will be triggered when the player interacts with this object")]
    [SerializeField] private SO_Dialogue dialogue;
    
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
        InteractionManager.instance.StartInteraction(dialogue);
    }
}
