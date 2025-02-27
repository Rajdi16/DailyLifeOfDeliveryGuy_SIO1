using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FuelConsumption
{
    // Quantité initiale de carburant
    public float fuel = 100000;
    // Taux de consommation de carburant en courant
    public float fuelConsumptionRateRunning = 3;
    // Taux de consommation de carburant en marchant
    public float fuelConsumptionRateWalking = 1;

    // Référence au mouvement de la voiture
    private LivraisonCarMovement carMovement;

    private void Start()
    {
        // Obtient le composant LivraisonCarMovement attaché à l'objet
        carMovement = GetComponent<LivraisonCarMovement>();
    }

    private void Update()
    {
        // Vérifie si il reste du carburant
        if (fuel > 0)
        {
            // Si la voiture est en train de courir, consomme du carburant à un taux plus élevé
            if (carMovement.isRunning)
            {
                fuel -= fuelConsumptionRateRunning * Time.deltaTime;
            }
            // Sinon, consomme du carburant à un taux plus faible
            else
            {
                fuel -= fuelConsumptionRateWalking * Time.deltaTime;
            }

            // Si le carburant est épuisé, arrête la voiture
            if (fuel <= 0)
            {
                fuel = 0;
                carMovement.speed = 0;
            }
        }
    }

    // Méthode pour ajouter du carburant
    private void addFuel(int quantite)
    {
        fuel += quantite;
    }
}
