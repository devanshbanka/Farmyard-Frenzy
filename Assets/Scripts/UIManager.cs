using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject GameOverScreen;
    public GameObject PlayingScreen;
    public GameObject CountObject;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI Best;
    public TextMeshProUGUI CountText;

    public float count = 0;
    private int highscore;

    private bool isGameOver = false;

    private void Start()
    {
        isGameOver = false;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }

    private void Update()
    {
        if (count > highscore)
        {
            int highscore = (int)count;
            Score.text = "Score: " + count;
            Best.text = "Best: " + count;

            PlayerPrefs.SetInt("highscore", highscore);
        }
        else
        {
            Score.text = "Score: " + count;
            Best.text = "Best: " + highscore;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetGameOver()
    {
        isGameOver = true;
        GameOverScreen.SetActive(true);
        PlayingScreen.SetActive(false);
        CountObject.SetActive(false);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void CountUp()
    {
        count += 0.5f;
        CountText.text = ""+count;
    }
}