using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LivraisonCarMovement : MonoBehaviour
{
    public float speed; // Vitesse actuelle de la voiture
    [SerializeField] private float runSpeed; // Vitesse de course
    [SerializeField] private float walkSpeed; // Vitesse de marche
    [SerializeField] private float horizontalSpeed; // Vitesse de rotation horizontale

    public bool isRunning = false; // Indique si la voiture est en train de courir
    private Vector2 input; // Stocke les entrées de l'utilisateur
    [SerializeField] private Rigidbody rigidbody; // Référence au Rigidbody de la voiture

    private bool isGrounded = true; // Indique si la voiture est au sol

    [SerializeField] private GameObject player; // Référence au joueur

    private FuelConsumption fuelConsumption; // Référence à la consommation de carburant

    private void Start()
    {
        // Initialisation des composants
        rigidbody = GetComponent<Rigidbody>();
        fuelConsumption = GetComponent<FuelConsumption>();
    }

    private void Update()
    {
        // Vérifie si la touche LeftShift est enfoncée pour déterminer la vitesse
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }
        else
        {
            speed = walkSpeed;
            isRunning = false;
        }

        // Vérifie si le bouton de la souris est enfoncé pour instancier le joueur et détruire la voiture
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.deltaTime != 0)
        {
            Instantiate(player, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

        // Récupère les entrées de l'utilisateur pour le mouvement
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Vérifie si la voiture est au sol et si la touche Espace est enfoncée pour désactiver l'état au sol
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        // Applique la rotation en fonction des entrées horizontales
        Vector3 desireRotation = new Vector3(0, input.x * horizontalSpeed * Time.deltaTime, 0);
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(desireRotation));

        // Applique le mouvement en fonction des entrées verticales
        Vector3 movement = new Vector3(transform.forward.x * input.y * speed * Time.deltaTime, 0, transform.forward.z * input.y * speed * Time.deltaTime);
        rigidbody.MovePosition(transform.position + movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si la collision est avec le sol pour activer l'état au sol
        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
    }
}
