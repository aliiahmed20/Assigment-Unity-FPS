using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] GameObject coin;
    [SerializeField] float speed = 15.0f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpHeight = 3.0f;
    [SerializeField] Text score;
    float x, z;
    Vector3 newPos;
    float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    private float gravity = -9.81f;
    Vector3 velocity;
    bool isGrounded;
    int coinsCollected;






    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward*z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {        
                coinsCollected++;
                score.text = "Score: " + coinsCollected;
                Destroy(other.gameObject);
                x = Random.Range(-28.0f, 18.0f);
                z = Random.Range(-28.0f, 18.0f);
                newPos = new Vector3(x, 0, z);
                GameObject newGameObject = Instantiate(coin, newPos, Quaternion.identity);          
        }
    }


}
