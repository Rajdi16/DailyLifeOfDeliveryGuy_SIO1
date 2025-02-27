using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelConsumption : MonoBehaviour
{
    public float fuel = 100000;
    public float fuelConsumptionRateRunning = 3;
    public float fuelConsumptionRateWalking = 1;

    private LivraisonCarMovement carMovement;
    private void Start()
    {
        carMovement = GetComponent<LivraisonCarMovement>();
    }

    private void Update()
    {
        print (fuel);
        if (fuel > 0)
        {
            if (LivraisonCarMovement.isRunning)
            {
                fuel -= fuelConsumptionRateRunning;
            }
            else
            {
                fuel -= fuelConsumptionRateWalking;
            }

            if (fuel <= 0)
            {
                fuel = 0;
                print("Out of fuel");
            }
        }
    }

    private void addFuel(int quantite)
    {
        fuel += quantite;
    }
}
