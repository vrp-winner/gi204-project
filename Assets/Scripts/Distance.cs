using System;
using UnityEngine;

public class Distance : MonoBehaviour
{
    private int score;
    
    private PlayerController player;
    private bool gameFinish = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Car").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetIsGameOver() == false)
        {
            score = ((int)Time.time)*100;
        }
        
        if (player.GetIsGameOver() == true && !gameFinish)
        {
            Debug.Log("Distance: "+score);
            gameFinish = true;
        }
    }
}
