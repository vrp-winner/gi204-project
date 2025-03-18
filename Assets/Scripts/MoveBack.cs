using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed = 10f;
    
    private PlayerController playerController; // อ้างอิงถึง PlayerController เพื่อตรวจสอบว่าเกมจบหรือยัง
    void Start()
    {
        // ค้นหา "Car" PlayerController มาใช้
        playerController = GameObject.Find("Car").GetComponent<PlayerController>();
    }

    void Update()
    {
        // ถ้าเกมยังไม่จบ ให้วัตถุเคลื่อนที่ไปข้างหลังหาผู้เล่น
        if (playerController.GetIsGameOver() == false)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        
    }
}
