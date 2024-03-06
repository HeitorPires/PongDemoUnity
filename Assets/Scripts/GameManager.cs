using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Transform playerPaddle;
    public Transform enemyrPaddle;

    public BallController ballController;

    public int playerScore = 0;
    public int enemyrScore = 0;

    public TextMeshProUGUI textPointPlayer;
    public TextMeshProUGUI textPointEnemy;

    public int winPoints = 5;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }


    public void ResetGame()
    {
        playerPaddle.position = new Vector3(-7f, 0f, 0f);
        enemyrPaddle.position = new Vector3(7f, 0f, 0f);

        ballController.ResetBall();

        playerScore = 0;
        enemyrScore = 0;

        textPointPlayer.text = playerScore.ToString();
        textPointEnemy.text = enemyrScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyrScore++;
        textPointEnemy.text = enemyrScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (playerScore >= winPoints || enemyrScore >= winPoints)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > enemyrScore);
        textEndGame.text = $"Vitória de {winner}";
        SaveController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
