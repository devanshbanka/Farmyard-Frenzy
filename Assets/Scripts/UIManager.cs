using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject GameOverScreen;
    public GameObject PlayingScreen;
    public GameObject CountObject;
    public GameObject HomeScreen;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI Best;
    public TextMeshProUGUI CountText;

    public GameObject ExplosionPrefab;

    public int count = 0;
    private int highscore;

    private bool isGameOver = false;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }

    private void Update()
    {
        if (count > highscore)
        {
            highscore = count;
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

    public void SetGameStart()
    {
        isGameOver = false;
        PlayingScreen.SetActive(true);
        CountObject.SetActive(true);
        HomeScreen.SetActive(false);
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
        count += 1;
        CountText.text = ""+count;
    }

    public void Explosion(Vector3 Position)
    {
        ExplosionPrefab.SetActive(true);
        GameObject explosion = Instantiate(ExplosionPrefab, Position, Quaternion.identity);
        ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }
        Destroy(explosion, ps.main.duration);
    }
}