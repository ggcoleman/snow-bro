using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField] float torqueAmount = 1.0f;
    [SerializeField] float boostMultiplier = 2f;
    [SerializeField] float brakeMultiplier = 0.5f;

    [SerializeField] float speed = 20f;

    SurfaceEffector2D surfaceEffector2D;


    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        surfaceEffector2D.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {

            RotatePlayer();
            RespondToBoostAndBrake();

        }

    }

    private void RespondToBoostAndBrake()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = speed * boostMultiplier;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = speed * brakeMultiplier;
        }
        else
        {
            surfaceEffector2D.speed = speed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
    public void DisableControls()
    {
        canMove = false;
    }

}
