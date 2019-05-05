using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    public GameObject heart1, heart2, heart3;
    private SpriteRenderer heart1Sp, heart2Sp, heart3Sp;
    public Sprite fullHeart, HalfHeart, NoHeart;
    public GameObject gameOverObject, VictoryObject;
    public GameObject particles;
    public Text text, gameOver;
    public float timeLeft;
    float waitTime = 3f;

    public Button continueGame, exitGame;
    public Button playagain, exit;

    public GameObject pauseGame, finished;
    bool show;


    // Use this for initialization
    void Start()
    {
        heart1Sp = heart1.GetComponent<SpriteRenderer>();
        heart2Sp = heart2.GetComponent<SpriteRenderer>();
        heart3Sp = heart3.GetComponent<SpriteRenderer>();
        gameOver.enabled = false;
        show = false;
        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            show = !show;
            PauseGame();
        }



    }

    public bool PauseGame()
    {

        if (show == true)
        {
            pauseGame.SetActive(true);
            return true;
        }

        pauseGame.SetActive(false);
        return false;

    }

    public void ContinueGame()
    {
        pauseGame.SetActive(false);
        show = false;
    }

    public void ExitGame()
    {
        pauseGame.SetActive(false);
        gameObject.SetActive(true);
        SceneManager.LoadScene("Introduction", LoadSceneMode.Single);
    }

    public void BackToIntro()
    {
        SceneManager.LoadScene("Introduction", LoadSceneMode.Single);
    }

    public void PlayAgain()
    {

        gameObject.SetActive(false);
        SceneManager.LoadScene("Classroom");
    }


    public void GameOver()
    {
        gameOverObject.SetActive(true);
    }

    public void Victory()
    {
        finished.SetActive(true);
    }

    public void UpdateHealth(int health)
    {
        switch (health)
        {
            case 6:
                heart1Sp.sprite = fullHeart;
                heart2Sp.sprite = fullHeart;
                heart3Sp.sprite = fullHeart;
                break;
            case 5:
                heart1Sp.sprite = fullHeart;

                heart2Sp.sprite = fullHeart;
                heart3Sp.sprite = HalfHeart;
                break;
            case 4:
                heart1Sp.sprite = fullHeart;
                heart2Sp.sprite = fullHeart;
                heart3Sp.sprite = NoHeart;
                break;
            case 3:
                heart1Sp.sprite = fullHeart;
                heart2Sp.sprite = HalfHeart;
                heart3Sp.sprite = NoHeart;
                break;
            case 2:
                heart1Sp.sprite = fullHeart;
                heart2Sp.sprite = NoHeart;
                heart3Sp.sprite = NoHeart;
                break;
            case 1:
                heart1Sp.sprite = HalfHeart;
                heart2Sp.sprite = NoHeart;
                heart3Sp.sprite = NoHeart;
                break;
            case 0:
                heart1Sp.sprite = NoHeart;
                heart2Sp.sprite = NoHeart;
                heart3Sp.sprite = NoHeart;
                break;
        }
    }

    public float UpdateScore()
    {
        if (!PauseGame())
        {
            CheckpointController checkpoint = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CheckpointController>();
            text.fontStyle = FontStyle.Bold;

            float a = 0.5f * Time.deltaTime;

            timeLeft -= a;

            text.text = "Time Left:" + Mathf.Round(timeLeft).ToString();

            if (timeLeft <= 120.1 && timeLeft >= 120)
            {
                checkpoint.timeDecreased();

            }
            else if(timeLeft <= 60.1 && timeLeft >= 60)
            {
                checkpoint.timeDecreased();
            }

            if (timeLeft < 30 && timeLeft > 0)
                text.color = new Color(139, 0, 0);

            if (timeLeft <= 0)
            {
                timeLeft = 0;
                gameOver.enabled = true;

                waitTime -= a;

                if (waitTime <= 0)
                {
                    gameOver.enabled = false;
                    GameOver();
                }
                return timeLeft;
            }
        }
        return timeLeft;
    }


}
