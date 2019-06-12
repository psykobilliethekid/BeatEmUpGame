using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private PlayerAnimation player_Animation;
    private Rigidbody myBody;

    public float walk_Speed = 3f;
    public float z_Speed = 1.5f;

    private float rotation_Y = -90f;
    private float rotation_Speed = 15f;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        //player_Animation = GetComponentInChildren<PlayerAnimation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DetectMovement()
    {
        myBody.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_Speed),
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_Speed));
    }


} //class










































