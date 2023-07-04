using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController controller;          //Collider for the character - setting physical attributes for the player

    public float speed = 12f;                       //Movement speed of character in Vector3

    public float gravity = -12f;                    //Pushing character down after jumping - acts like real gravity
    public float jumpHeight = 1f;                   //Maximum jump limit for character in Vector3

    Vector3 velocity;                               

    public Transform groundCheck;

    public float groundDistance = 0.4f;             //A groundcheck is a collider added to the ground of the map. This applies physical attributes to the player to land on the ground after jumping.
                                                    //Avoids phasing through ground and objects
    public LayerMask groundMask;

    bool isGrounded;                                //bool to check if player is grounded

   

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0) 
        {                                                                                       //In vector3 format - adds momentum while jumping and landing on the ground
            velocity.y = -2f;                                                                   
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;                             //The character can face any directions of X,Y,Z and be able to move

        controller.Move(move * speed * Time.deltaTime);                                         //Speed increases with time
       
        if (Input.GetButton("Jump") && isGrounded)                                              //Jumping is only initiated when the character is on the gound
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;                                //velocity of jump increases with time - used in realistic games

        controller.Move(velocity * Time.deltaTime);

        
    }
}
