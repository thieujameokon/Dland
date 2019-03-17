using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//This Script controls the complete game play.
public class GameController : MonoBehaviour
{
    
    public GameObject OrangeCar;
    public GameObject BlueCar;
    public GameObject[] BlueGameObjects;
    public GameObject[] OrangeGameObjects;
    GameObject Blue;
    GameObject Orange;
    public float spawnWait;
    public float startWait;
    public static int speed;
    float[] XPosition = new float[2] { 0.75f, 2.25f };
    public static bool BlueAtLeft = false;
    public static bool OrangeAtLeft = false;
    public static bool IsGameOver;
    public Text GameScoreText;
    public static int score = 0;
    int highscore;
    public GameObject GameOverCanvas;
    public GameObject GameCanvas;
    public GameObject StartCanvas;
    public Text ScoreText;
    public Text HighScoreText;
    // Use this for initialization
    void Start()
    {
        GameScoreText.text = score.ToString();
        //this sets timescale to 1 at start.
        Time.timeScale = 1;
        //this derives the value of highscore at start.
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        //this disables GameOverCanves and GameCanvas, enables startCanvas.
        GameOverCanvas.SetActive(false);
        GameCanvas.SetActive(false);
        StartCanvas.SetActive(true);
        GameController.speed = 3; 
    }
    //this starts the spawn wave of the cubes and circles.
     IEnumerator SpawnWaves()
    {
        //wait of startWait(int) seconds
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 100; i++)
            {
                //Setting orange gameObject Position randomly between 2 XPosition.
                float OrangeXPos = XPosition[Random.Range(0, XPosition.Length)];
                Vector3 OrangePosition = new Vector3(OrangeXPos, 6.5f, 0);
                //Randomly choose between orange cube & circle.
                Orange = OrangeGameObjects[Random.Range(0, OrangeGameObjects.Length)];
                //create orange gameobject at OrangePosition.
                Instantiate(Orange, OrangePosition, Quaternion.identity);
                //wait between next drop
                yield return new WaitForSeconds(spawnWait);
                //Setting blue gameObject Position randomly between 2 XPosition.
                float BlueXPos = XPosition[Random.Range(0, XPosition.Length)];
                Vector3 BluePosition = new Vector3(-BlueXPos, 6.5f, 0);
                //Randomly choose between blue cube & circle.
                Blue = BlueGameObjects[Random.Range(0, BlueGameObjects.Length)];
                //create blue gameobject at BluePosition.
                Instantiate(Blue, BluePosition, Quaternion.identity);
                //wait between next drop
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Action on left key Pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Bấm Trái");
            LeftButton();
        }//Action on right key pressed 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Bấm Phải");
            RightButton();
        }
        //Checking if game is not over.
    }

    public void StartGame()
    {
        //On Start Game button pressed, disable StartCanvas and GameCanvas & starting the spawn of cubes and circles.
        StartCanvas.SetActive(false);
        GameCanvas.SetActive(true);
        StartCoroutine(SpawnWaves());
        IsGameOver = false;
    }

    public void AddScore()
    {
        //Add score by 1 and showing that score to GameScoreText.
        score += 1;
        GameScoreText.text = score.ToString();
    }

    public void LeftButton()
    {
        //on pressing left button, if BlueAtLeft is true set it to false and if it is false set it to true.
        if (BlueAtLeft)
        {
            BlueAtLeft = false;
        }
        else
        {
            BlueAtLeft = true;
        }
    }

    public void RightButton()
    {
        //on pressing right button, if OrangeAtLeft is true set it to false and if it is false set it to true.
        if (OrangeAtLeft)
        {
            OrangeAtLeft = false;
        }
        else
        {
            OrangeAtLeft = true;
        }
    }

    public void Restart()
    {
        //Reload the game on restart button
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        //sets is isGameOver to true
        IsGameOver = true;
        //Plays GameOverSound
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        //Pause the time
        Time.timeScale = 0;
        //activate the gameover canvas
        GameOverCanvas.SetActive(true);
        //show the score value on ScoreText
        ScoreText.text = "Score:" + score.ToString();
        //if score is greater than highscore change the stored value of highscore
        if (score > highscore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        //show highscore value on HighScoreText
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        HighScoreText.text = "Highscore:" + highscore.ToString();
        GameController.score = 0; 
    }
}
