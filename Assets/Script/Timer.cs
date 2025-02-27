using System.Collections;
using System.Collections.Generic;
using UnityEngine; // to use the functionality of Unity
using TMPro; // TMPro = TextMesh Pro , for improved text in unity

public class Timer : MonoBehaviour //Provides the fonctionnality to control game objetcs.
{
    [SerializeField] TextMeshProUGUI timerText; 
    float elapsedTime; // Creation of variable to store time from the beginning of the game
    void Update() //each time the game is restarted, the timer is reset to 0
    {
        elapsedTime += Time.deltaTime; //Time increment
        timerText.text = elapsedTime.ToString(); //display time as a character string  
        //Below, it calculates the time
        int minutes = Mathf.FloorToInt(elapsedTime / 60); // Convert time to minute 
        //Mathf.FloorToint is used to round a decimal number to the nearest integer
        int seconds = Mathf.FloorToInt(elapsedTime % 60); //Divide the time by 60, for the seconds 
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //To display the minutes and seconds in a format (MM:SS)
    }
}
