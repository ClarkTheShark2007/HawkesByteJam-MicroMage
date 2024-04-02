using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
 
    public static Vector2 Movement;
    private InputAction moveAction;
    private PlayerInput playerInput;
    private InventoryManager inventoryManager;


    private void Awake() 
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];

        inventoryManager  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<InventoryManager>(); 
    }

    private void Update() 
    {
        Movement = moveAction.ReadValue<Vector2>();

        if(Input.GetMouseButtonDown(0))
        {
            inventoryManager.getSpellAtIndex(0).castSpell();
        }
        if(Input.GetMouseButtonDown(1))
        {
          inventoryManager.getSpellAtIndex(1).castSpell();
        }
    }
    

}
