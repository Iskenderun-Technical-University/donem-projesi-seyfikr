using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private float moveSpeed = 150f;
    private float jumpSpeed = 40f;
    private float gravityScale = 270f;
    private float slideSpeed = 55f;
    private int laneIndex = 0;
    Animator anim;
    public GameObject Car;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
       

    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Force);
        rb.AddForce(Physics.gravity * gravityScale * Time.fixedDeltaTime, ForceMode.Force);
    }
    private void Update()
    {

      
        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0f)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            StartCoroutine(jump());

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (laneIndex != -1)
            {
                rb.AddForce(Vector3.left * slideSpeed, ForceMode.Impulse);
                laneIndex--;
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (laneIndex != 1)
            {
                rb.AddForce(Vector3.right * slideSpeed, ForceMode.Impulse);
                laneIndex++;
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector3.down * jumpSpeed, ForceMode.Impulse);
            StartCoroutine(loop());

        }
    }
    IEnumerator jump()
    {
        anim.SetBool("jump", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("jump", false);
    }
    IEnumerator loop()
    {

        anim.SetBool("loop", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("loop", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarMove")
        {
            Car.GetComponent<CarScript>().CarMove();
        }
    }
}