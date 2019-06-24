﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject left_Arm_Attack_Point, right_Arm_Attack_Point, left_Leg_Attack_Point, right_Leg_Attack_Point;

    public float stand_Up_Timer = 2f;

    private CharacterAnimation animationScript;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip whoosh_Sound, fall_Sound, ground_Hit_Sound, dead_Sound;

    private EnemyMovement enemy_Movement;

    private ShakeCamera shakeCamera;

    void Awake()
    {
        animationScript = GetComponent<CharacterAnimation>();

        audioSource = GetComponent<AudioSource>();

        if(gameObject.CompareTag(Tags.ENEMY_TAG))
        {
            enemy_Movement = GetComponentInParent<EnemyMovement>();
        }

        shakeCamera = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<ShakeCamera>();
    }

    void Left_Arm_Attack_On()
    {
        left_Arm_Attack_Point.SetActive(true);
    }

    void Left_Arm_Attack_Off()
    {
        if (left_Arm_Attack_Point.activeInHierarchy)
        {
            left_Arm_Attack_Point.SetActive(false);
        }
    }

    void Right_Arm_Attack_On()
    {
        right_Arm_Attack_Point.SetActive(true);
    }

    void Right_Arm_Attack_Off()
    {
        if (right_Arm_Attack_Point.activeInHierarchy)
        {
            right_Arm_Attack_Point.SetActive(false);
        }
    }

    void Left_Leg_Attack_On()
    {
        left_Leg_Attack_Point.SetActive(true);
    }

    void Left_Leg_Attack_Off()
    {
        if(left_Leg_Attack_Point.activeInHierarchy)
        {
            left_Leg_Attack_Point.SetActive(false);
        }
    }

    void Right_Leg_Attack_On()
    {
        right_Leg_Attack_Point.SetActive(true);
    }

    void Right_Leg_Attack_Off()
    {
        if (right_Leg_Attack_Point.activeInHierarchy)
        {
            right_Leg_Attack_Point.SetActive(false);
        }
    }

    void TagLeft_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.LEFT_ARM_TAG;
    }

    void UnTagLeft_Arm()
    {
        left_Arm_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void TagLeft_Leg()
    {
        left_Leg_Attack_Point.tag = Tags.LEFT_LEG_TAG;
    }

    void UnTagLeft_Leg()
    {
        left_Leg_Attack_Point.tag = Tags.UNTAGGED_TAG;
    }

    void Enemy_StandUp()
    {
        StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(stand_Up_Timer);
        animationScript.StandUp();
    }

    // Play attack sound
    public void Attack_FX_Sound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whoosh_Sound;
        audioSource.Play();
    }

    void CharacterDiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = dead_Sound;
        audioSource.Play();
    }

    void Enemy_KnockedDown()
    {
        audioSource.clip = fall_Sound;
        audioSource.Play();
    }

    void Enemy_HitGround()
    {
        audioSource.clip = ground_Hit_Sound;
        audioSource.Play();
    }

    // Stops Enemy from instantly getting up after being knocked down
    void DisableMovement()
    {
        enemy_Movement.enabled = false;

        // Makes it so the Player can't hit enemy while on the ground
        // Sets enemy parent to the default layer
        transform.parent.gameObject.layer = 0;
    }

    // Enables Enemy movement after delay timer hits 2sec
    void EnableMovement()
    {
        enemy_Movement.enabled = true;

        // Sets enemy parent to the enemy layer
        transform.parent.gameObject.layer = 9;
    }

    // Shake camera when character falls to the ground
    void ShakeCameraOnFall()
    {
        shakeCamera.ShouldShake = true;
    }

    // When Enemy dies (need to set up for player)
    void CharacterDied()
    {
        Invoke("DeactivateGameObject", 2f);
    }


    // Deactivate Enemy Game Object
    void DeactivateGameObject()
    {
        // Spawns enemy when one dies
        EnemyManager.instance.SpawnEnemy();
        gameObject.SetActive(false);
    }
    

} // class
