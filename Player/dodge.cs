using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dodge : MonoBehaviour
{
    public float rollSpeed = 10f; // Velocidade do rolamento
    public float rollDuration = 0.5f; // Duração do rolamento
    public float boostForce = 20f; // Força do impulso
    private bool isRolling = false;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.AddForce(transform.up * 20);
        }
    }

}
