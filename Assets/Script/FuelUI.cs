using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    public Text fuelText;
    public FuelConsumption fuelConsumption;

    private void Update()
    {
        fuelText.text = "Fuel: " + Mathf.Max(fuelConsumption.fuel, 0).ToString("F2");
    }
}
