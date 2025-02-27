using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    public TextMeshProUGUI FuelOnJauge; // Texte sur la jauge
    public Image Pointe; // Pointe de la jauge
    public FuelConsumption fuelConsumption; // Fuel restant

    private void Start()
    {
        FuelOnJauge.text = "000"; // Par défaut
        fuelConsumption = GetComponent<FuelConsumption>();
    }
    private void Update()
    {
        FuelOnJauge.text = Mathf.Max(fuelConsumption.fuel, 0).ToString("F2"); // Affichage du fuel restant

        float rotationAngle = Mathf.Lerp(0f, 90f, fuelConsumption.fuel / 100f); // Il faudra régler pour que l'éguille s'affiche bien

        Pointe.transform.rotation = Quaternion.Euler(0, 0, -rotationAngle); // Rotation de la pointe
    }
}
