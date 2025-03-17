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
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
