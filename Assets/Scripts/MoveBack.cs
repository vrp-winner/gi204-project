using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed = 10f;
    private float currentSpeed;
    
    private PlayerController playerController; // อ้างอิงถึง PlayerController เพื่อตรวจสอบว่าเกมจบหรือยัง
    void Start()
    {
        // ค้นหา "Car" PlayerController มาใช้
        playerController = GameObject.Find("Car").GetComponent<PlayerController>();
        currentSpeed = speed;
    }

    void Update()
    {
        // ถ้าเกมยังไม่จบ ให้วัตถุเคลื่อนที่ไปข้างหลังหาผู้เล่น
        if (playerController.GetIsGameOver() == false)
        {
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        currentSpeed = speed;
    }
}
