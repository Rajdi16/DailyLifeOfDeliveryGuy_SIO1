using UnityEngine;
public class CarrefourManager : MonoBehaviour
{
    public Transform[] sorties; // Il faut l'assigné dans l'inspecteur je sais pas c où

    public Transform GetRandomExit() // Retourne une sortie au hasard
    {
        if (sorties.Length == 0) return null; //Si il n'y a pas de sortie, on retourne null
        return sorties[Random.Range(0, sorties.Length)]; //Sinon on retourne une sortie au hasard qui est dans sorties grâce à 
    }
}