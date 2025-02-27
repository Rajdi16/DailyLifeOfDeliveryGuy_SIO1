using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivraisonCarMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float horizontalSpeed;

    public bool isRunning = false;
    private Vector2 input;
    [SerializeField] Rigidbody rigidbody;

    private bool isGrounded = true;

    [SerializeField] GameObject player;

    private FuelConsumption fuelConsumption;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        fuelConsumption = GetComponent<FuelConsumption>();
    }

    private void Update()
    {
        if (fuelConsumption.fuel > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runSpeed;
                isRunning = true;
            }
            else if (!Input.GetKey(KeyCode.LeftShift))
            {
                speed = walkSpeed;
                isRunning = false;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && Time.deltaTime != 0)
            {
                Instantiate(player, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }

            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
            }
        }
        else
        {
            speed = 0;
        }
    }

    void FixedUpdate()
    {
        if (fuelConsumption.fuel > 0)
        {
            Vector3 desireRotation = new Vector3(0, input.x * horizontalSpeed * Time.deltaTime, 0);
            rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(desireRotation));

            Vector3 movement = new Vector3(transform.forward.x * input.y * speed * Time.deltaTime, 0, transform.forward.z * input.y * speed * Time.deltaTime);
            rigidbody.MovePosition(transform.position + movement);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }
}