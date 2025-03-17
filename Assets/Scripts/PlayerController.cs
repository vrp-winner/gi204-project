using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    private InputAction moveAction;
    
    public bool isGameOver = false; // เช็คว่าเกมจบหรือยัง
    
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        // ถ้าเกมจบแล้ว ไม่ต้องให้ผู้เล่นขยับ
        if(isGameOver) return;
        
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
        
        // จำกัดขอบเขตการเคลื่อนที่ของผู้เล่น
        float xRange = 4.5f; // ขอบเขตซ้าย-ขวา
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // ถ้าชนกับวัตถุที่มี tag "Obstacle" ให้จบเกม
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
        }
    }
}
