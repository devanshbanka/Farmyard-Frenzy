using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : MonoBehaviour
{
    public GameObject PlayingScreen;
    public GameObject CountObject;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        PlayingScreen.SetActive(true);
        CountObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
