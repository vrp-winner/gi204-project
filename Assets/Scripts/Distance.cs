using TMPro;
using UnityEngine;

public class Distance : MonoBehaviour
{
    private float score; // เปลี่ยนไปใช้ float เพื่อรับค่า current speed ใน PlayerController
    
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
            score += playerController.GetCurrentSpeed() * Time.deltaTime; // เปลี่ยนไปใช้ Time.deltaTime จะเสถียรกว่า
            distanceText.text = "Distance: " + Mathf.RoundToInt(score); // ปัด float เป็น int
        }
        
        /*if (player.GetIsGameOver() == true && !gameFinish)
        {
            Debug.Log("Distance: "+score);
            gameFinish = true;
        }*/
    }
}