using System;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private DiceRoll dice;
    
    [SerializeField]
    private TextMeshProUGUI text;

    private void Update()
    {
        if (dice.diceFaceNum != 0)
        {
            text.text = dice.diceFaceNum.ToString();
        }
    }
}