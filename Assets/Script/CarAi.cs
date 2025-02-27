using UnityEngine;

public class CarAi : MonoBehaviour
{
    public float speed = 5f; // Vitesse de la voiture
    private bool isStopped = false; // Indique si la voiture est arrêtée
    private Transform target = null; // Target uniquement pour les carrefours

    void Update()
    {
        if (isStopped) return; // Si la voiture est arrêtée, on ne bouge pas

        if (target == null)
        {
            // Avancer tout droit
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            // Suivre la target si elle existe (après un carrefour)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                target = null; // Une fois la sortie atteinte, repartir tout droit
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carrefour"))
        {
            CarrefourManager carrefour = other.GetComponent<CarrefourManager>();
            if (carrefour != null)
            {
                target = carrefour.GetRandomExit(); // Prendre une sortie aléatoire
            }
        }

        if (other.CompareTag("Car")) // Stopper la voiture si une autre voiture est détectée
        {
            isStopped = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            isStopped = false; // Reprendre la marche
        }
    }
}
