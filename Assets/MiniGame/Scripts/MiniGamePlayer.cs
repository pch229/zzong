using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGamePlayer : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public float moveSpeed = 1.5f;
    public float minX = -6f;
    public float maxX = 8.13f;

    public static int score = 0;  // 먹은 사과의 수
    private int highScore;
    public Text scoreText;
    public bool isGameOver;
    public GameObject gameOver;
    public GameObject scoreBoard;
    public GameObject joyStick;
    public Text gameOverText;
    public bool isPause;
    public GameObject startButton;

    public bool isButtonDown_left;
    public bool isButtonDown_right;

    public GameObject isOutUI;

    private void Start()
    {
        UpdateScoreText();
        isGameOver = false;
        isPause = false;
        isButtonDown_left = false;
        isButtonDown_right = false;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        Time.timeScale = 0;
}

    void ActivateFunctions()
    {
        Time.timeScale = 1;
        Debug.Log("1");
    }

        private void Update()
    {
        if(isGameOver)
        {
            GameOver();
        }
    }

    void OnTriggerEnter(Collider other )
    {
        if (other.gameObject.CompareTag ("Apple"))
        {
            Debug.Log("apple");
            score++;
            UpdateScoreText();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Bug")
        {
            Destroy(other.gameObject);
            isGameOver = true;
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "점수: " + score;
    }

    void GameOver()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        gameOverText.text = "점수: " + score + "   /   " + "최고점수: " + highScore;
        gameOver.SetActive(true);
        scoreBoard.SetActive(false);
        joyStick.SetActive(false);
    }
    
    private void FixedUpdate()
    {
        if (!isGameOver)
        {
            if (transform.position.x > minX)
            {
                if (isButtonDown_left)
                    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            else
            {
                if (isButtonDown_left)
                {
                    moveSpeed = 0;
                }
                else 
                    moveSpeed = 5;
            }

            if (transform.position.x < maxX)
            {
                if (isButtonDown_right)
                    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                if (isButtonDown_right)
                {
                    moveSpeed = 0;
                }
                else
                    moveSpeed = 5;
            }
        }
    }

    public void PointerDown_left()
    {
        isButtonDown_left = true;
    }

    public void PointerUp_left()
    {
        isButtonDown_left = false;
    }

    public void PointerDown_right()
    {
        isButtonDown_right = true;
    }

    public void PointerUp_right()
    {
        isButtonDown_right = false;
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        startButton.SetActive(false);
    }

    public void OutGame()
    {
        Time.timeScale = 0;
        isOutUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("MiniGame");
    }

    public void GoForest()
    {
        isOutUI.SetActive(false);
        gameOver.SetActive(false);
        // 아래 거 활성화 하기
        SceneManager.LoadScene("4_Forest");
    }

    public void Continue()
    {
        Time.timeScale = 1;
        isOutUI.SetActive(false);
    }

    public void Pause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
}
