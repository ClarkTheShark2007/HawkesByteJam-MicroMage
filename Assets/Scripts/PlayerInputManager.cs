// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerInputManager : MonoBehaviour
// {
//     private Spell primary;
//     private Spell secondary;
//     void Start()
//     {
//         primary = GameObject.FindWithTag("Player")?.GetComponents<Spell>()[0];
//         secondary = GameObject.FindWithTag("Player")?.GetComponents<Spell>()[1];
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         if(Input.GetMouseButtonDown(0))
//         {
//             primary.castSpell();
//         }
//          if(Input.GetMouseButtonDown(1))
//         {
//            secondary.castSpell();
//         }


//     }
// }
