using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{

    [SerializeField]
    int row, col;

    [SerializeField]
    GameObject myText;

    public bool hasPlayed;

    private void Awake()
    {
        myText.GetComponent<Text>().text = "";
        hasPlayed = false;

    }

    public void SetScore(bool isPlayer)
    {
        if(isPlayer)
        {
            myText.GetComponent<Text>().text = "X";
            myText.GetComponent<Text>().color = new Color(0, 0, 1);
            hasPlayed = true;
        }
        else
        {
            myText.GetComponent<Text>().text = "O";
            myText.GetComponent<Text>().color = new Color(0, 1, 0);
            hasPlayed = true;
        }
        GameManager.gameManager.DetermineWinner(row, col, isPlayer);
    }
}
