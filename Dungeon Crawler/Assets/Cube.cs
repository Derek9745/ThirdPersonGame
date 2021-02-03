using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Cube : MonoBehaviour
{
    PlayerControls controls;
    public CharacterController controller;
    public Transform cam;
    Vector2 move;
    public HealthBarScript healthBar;
   

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public int maxHealth = 100;
    public int currentHealth;



    void Awake()
    {

        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
        controls.Gameplay.Damage.performed += ctx => TakeDamage(20);
       
       

        
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }



    void Update()
    {
       
       
        Vector3 direction = new Vector3(move.x * 2 , 0f, move.y * 2) * Time.deltaTime;

        if (direction.magnitude >= 0.01f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }

    }

    

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

   void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }


}

