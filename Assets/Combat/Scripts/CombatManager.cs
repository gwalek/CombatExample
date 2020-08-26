using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CombatManager : MonoBehaviour
{
    public static CombatManager reference;
    // Start is called before the first frame update

    int Player1Score = 0;
    int Player2Score = 0;
    public TextMeshProUGUI Player1ScoreField;
    public TextMeshProUGUI Player2ScoreField;


    void Awake()
    {
        // Singleton Setup
        reference = this; 
        // Ignoring Singleton check for simplicity 
    }

    // Update is called once per frame
    void Update()
    {
        // Update Player Hud fields 
        Player1ScoreField.text = "P1: " + Player1Score;
        Player2ScoreField.text = "P2: " + Player2Score;
    }

    // Needs to be public so we can access it from the reference. 
    public void AddScore(bool PlayerBool, int value)
    {
        // True: Player 1 Was killed, Credit Player 2
        // False: Player 2 Was Killed, Credit Player 1
        if (PlayerBool)
        {
            Player2Score += value; 
        }
        else
        {
            Player1Score += value;
        }
    }
}
