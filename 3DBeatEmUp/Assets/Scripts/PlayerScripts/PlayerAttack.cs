using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Available animations for combos
public enum ComboState
{
    NONE, 
    PUNCH_1,
    PUNCH_2, 
    PUNCH_3, 
    KICK_1, 
    KICK_2
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_Anim;

    private bool activateTimerToReset;

    private float default_Combo_Timer = 0.4f;
    private float current_Combo_Timer;

    private ComboState current_Combo_State;

    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Setting default combo timer and current combo state
        current_Combo_Timer = default_Combo_Timer;
        current_Combo_State = ComboState.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        // Play combo attacks
        ComboAttacks();

        // Allow repeat button presses for combos
        ResetComboState();
    }


    // Combo Attacks
    void ComboAttacks()
    {
        // Punch
        if(Input.GetKeyDown(KeyCode.Z))
        {

            // Continue the combo if it's punch_3, exit and 
            // go to X key if kick_1 or kick_2 is pressed
            if (current_Combo_State == ComboState.PUNCH_3 ||
                current_Combo_State == ComboState.KICK_1 ||
                current_Combo_State == ComboState.KICK_2)
                return;

            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if(current_Combo_State == ComboState.PUNCH_1)
            {
                player_Anim.Punch_1();
            }

            if (current_Combo_State == ComboState.PUNCH_2)
            {
                player_Anim.Punch_2();
            }

            if (current_Combo_State == ComboState.PUNCH_3)
            {
                player_Anim.Punch_3();
            }


        }

        // Kick
        if(Input.GetKeyDown(KeyCode.X))
        {
            // Exit of kick_2 or punch_3 is pressed because there
            // are no longer any combos to perform
            if (current_Combo_State == ComboState.KICK_2 ||
                current_Combo_State == ComboState.PUNCH_3)
                return;


            // If you've pressed nothing, punch_1 or punch_2
            // go to kick_1 to chain the combo
            if (current_Combo_State == ComboState.NONE ||
                current_Combo_State == ComboState.PUNCH_1 ||
                current_Combo_State == ComboState.PUNCH_2)
            {
                current_Combo_State = ComboState.KICK_1;
            }

            // If kick_1 is pressed continue the combo
            else if (current_Combo_State == ComboState.KICK_1)
            {
                // Move on to kick_2
                current_Combo_State++;
            }

            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;


            // Play the kick animation
            if (current_Combo_State == ComboState.KICK_1)
            {
                player_Anim.Kick_1();
            }

            if (current_Combo_State == ComboState.KICK_2)
            {
                player_Anim.Kick_2();
            }
        }
    }

    // Allows player to press punch or kick repeatedly
    void ResetComboState()
    {
        if(activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;

            // Can now chain the combo once again
            if(current_Combo_Timer <= 0f)
            {
                current_Combo_State = ComboState.NONE;

                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
            }
        }
    }


} // class
