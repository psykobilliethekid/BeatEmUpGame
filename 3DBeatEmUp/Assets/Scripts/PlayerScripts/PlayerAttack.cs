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
    }


    // Combo Attacks
    void ComboAttacks()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            player_Anim.Punch_1();

            // 1:14:18
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            player_Anim.Kick_1();
        }
    }


} // class
