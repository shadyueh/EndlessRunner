﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
