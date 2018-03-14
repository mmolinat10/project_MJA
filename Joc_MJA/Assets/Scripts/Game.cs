using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public bool endGame;
    public int pointsPj1 = 0, pointsPj2 = 0;
    public GameObject notificationPj1, notificationPj2;
    public GameObject puntuacionPj1, puntuacionPj2;
    public GameObject ball, ball2;

    // Use this for initialization
    void Start () {
        endGame = false;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && endGame)
        {
            if (SceneManager.GetActiveScene().name == "Game")
            {
                SceneManager.LoadScene(1);
            }
            else if (SceneManager.GetActiveScene().name == "game2")
            {
                SceneManager.LoadScene(2);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene(0);
        }

        if (pointsPj1 >= 10)
        {
            notificationPj1.GetComponent<Text>().text = "Player 1 wins";
            notificationPj2.GetComponent<Text>().text = "Player 2 loses";
            notificationPj1.SetActive(true);
            notificationPj2.SetActive(true);
            endGame = true;
            ball.SetActive(false);
            ball2.SetActive(false);
            Time.timeScale = 0;
        }
        if (pointsPj2 >= 10)
        {
            notificationPj1.GetComponent<Text>().text = "Player 1 loses";
            notificationPj2.GetComponent<Text>().text = "Player 2 wins";
            notificationPj1.SetActive(true);
            notificationPj2.SetActive(true);
            endGame = true;
            ball.SetActive(false);
            ball2.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
