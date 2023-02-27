using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlGame : MonoBehaviour
{
    public TextMeshProUGUI textNumberDice;

    public int numberDice;
    public int numberDiceTotal;


    public void RodaDado()
    {
        numberDice = Random.Range(1, 7);
        print("Tirou " + numberDice + " no dado.");

        textNumberDice.text = numberDice.ToString();

        numberDiceTotal += numberDice;
    }
}