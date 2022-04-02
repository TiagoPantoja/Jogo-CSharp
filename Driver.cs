using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 180f;
    [SerializeField] float moveSpeed = 25f;
    [SerializeField] float boostSpeed = 35f;
    [SerializeField] float slowSpeed = 15f;

    void Update()
    {
        // Podemos mostrar o efeito do Time.deltaTime com o frame travado Application.targetFrameRate = 200; ou 15;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // Tira a dependencia de frames por segundo do jogo
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
}
