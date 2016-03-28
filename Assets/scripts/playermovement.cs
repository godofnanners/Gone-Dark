﻿using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 input;
    private float maxSpeed = 5f;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }


        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {

            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 MS = Camera.main.ScreenToWorldPoint(mousePos);
        MS.y = transform.position.y;
        transform.LookAt(MS);

    }
}