using TMPro;
using UnityEngine;

public class Distance : MonoBehaviour
{
    private float score;
    
    private PlayerController playerController;
    
    public TextMeshProUGUI distanceText;
    
    //private bool gameFinish = false;
    
    void Start()
    {
        playerController = GameObject.Find("Car").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (!playerController.GetIsGameOver())
        {
            score += playerController.GetCurrentSpeed() * Time.deltaTime;
            distanceText.text = "Distance\n" + Mathf.RoundToInt(score);
        }
    }
}