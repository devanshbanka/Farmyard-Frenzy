using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : MonoBehaviour
{
    public int GameMode;

    public GameObject PlayingScreen;
    public GameObject CountObject;

    //public int GameMode = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void StartButton()
    //{
    //    PlayingScreen.SetActive(true);
    //    CountObject.SetActive(true);
    //    this.gameObject.SetActive(false);
    //}

    public void EasyButton()
    {
        GameMode = 1;
        UIManager.Instance.SetGameStart();
    }

    public void MediumButton()
    {
        GameMode = 2;
        UIManager.Instance.SetGameStart();
    }

    public void HardButton()
    {
        GameMode = 3;
        UIManager.Instance.SetGameStart();
    }
}
