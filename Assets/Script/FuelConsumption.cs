using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FuelConsumption
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
        
        if (fuel > 0)
        {
            if (carMovement.isRunning)
            {
                fuel -= fuelConsumptionRateRunning * Time.deltaTime;
            }
            else
            {
                fuel -= fuelConsumptionRateWalking * Time.deltaTime;
            }

            if (fuel <= 0)
            {
                fuel = 0;
                
                carMovement.speed = 0;
            }
        }
    }

    private void addFuel(int quantite)
    {
        fuel += quantite;
    }
}
