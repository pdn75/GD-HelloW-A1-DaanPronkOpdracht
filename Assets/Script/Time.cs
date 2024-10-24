using UnityEngine;
using UnityEngine.UI;
using System;

public class RealTimeClockWithDate : MonoBehaviour
{
    // Referentie naar de UI Text component
    public Text clockText;

    void Update()
    {
        // Verkrijg de huidige systeemtijd
        DateTime currentTime = DateTime.Now;

        // Format de datum als "dd-MM-yyyy" en de tijd als "HH:mm:ss", gescheiden door een "|"
        string dateTimeString = currentTime.ToString("dd-MM-yyyy | HH:mm:ss");

        // Toon de datum en tijd in de Text component
        clockText.text = dateTimeString;
    }
}
