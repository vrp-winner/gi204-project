using UnityEngine;

public class Distance : MonoBehaviour
{
    int score = 0;
    private PlayerController player;
    
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
            score++;
        }

        else
        {
            Debug.Log("Your Distance"+score);
        }
    }
}
