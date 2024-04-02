using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
 
    public static Vector2 Movement;
    private InputAction moveAction;
    private InputAction primarySpellCast;
    private InputAction secondarySpellCast;
    private PlayerInput playerInput;
    private InventoryManager inventoryManager;


    private void Awake() 
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        primarySpellCast = playerInput.actions["primarySpellCast"];
        secondarySpellCast = playerInput.actions["secondarySpellCast"];
        inventoryManager  = GameObject.FindGameObjectWithTag("Player")?.GetComponent<InventoryManager>(); 
    }

    private void Update() 
    {
        Movement = moveAction.ReadValue<Vector2>();

        if(primarySpellCast.WasPressedThisFrame())
        {
            inventoryManager.getSpellAtIndex(0).castSpell();
        }
        if(secondarySpellCast.WasPressedThisFrame())
        {
          inventoryManager.getSpellAtIndex(1).castSpell();
        }
    }
    

}
