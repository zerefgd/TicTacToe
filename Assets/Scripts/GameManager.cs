using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    bool isPlayer,hasGameFinished;

    [SerializeField]
    Text message;

    Board myBoard;

    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        myBoard = new Board();
        isPlayer = true;
        hasGameFinished = false;
    }

    public void GameRestart()
    {
        Debug.Log("Restarting");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit(
            );
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeText();
        }
    }

    void ChangeText()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null && !hit.collider.GetComponent<Click>().hasPlayed && !hasGameFinished)
        {
            hit.collider.gameObject.GetComponent<Click>().SetScore(isPlayer);
            if (hasGameFinished) return;
            if (isPlayer)
            {
                message.text = "O's turn";
            }
            else
            {
                message.text = "X's turn";
            }
            isPlayer = !isPlayer;
        }
    }

    public void DetermineWinner(int row, int col, bool isplayer1)
    {
        if(myBoard.UpdateCell(row,col,isplayer1))
        {
            hasGameFinished = true;
            message.text = isplayer1 ? "X Wins " : "O Wins";
        }
    }
}
