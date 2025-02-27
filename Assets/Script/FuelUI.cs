using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    public TextMeshProUGUI FuelOnJauge;
    public Image Pointe;
    public FuelConsumption fuelConsumption;

    private void Start()
    {
        FuelOnJauge.text = "000"; // Par défaut
    }
    private void Update()
    {
        FuelOnJauge.text = Mathf.Max(fuelConsumption.fuel, 0).ToString("F2");

        float rotationAngle = Mathf.Lerp(0f, 90f, fuelConsumption.fuel / 100f); // Il faudra régler pour que l'éguille s'affiche bien

        Pointe.transform.rotation = Quaternion.Euler(0, 0, -rotationAngle);
    }
}
