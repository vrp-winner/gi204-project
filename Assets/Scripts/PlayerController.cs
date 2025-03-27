using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public float onIceSpeed;
    
    public float currentSpeed;
    
    private bool isBoosted = false;
    
    private bool isGameOver = false; // เช็คว่าเกมจบหรือยัง
    
    private float boosterTimeRemaining = 0f;
    
    private InputAction moveAction;
    
    public bool GetIsGameOver()
    {
        return isGameOver;
    }
    
    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        // ถ้าเกมจบแล้ว ไม่ต้องให้ผู้เล่นขยับ
        if(isGameOver) return;

        if (isBoosted)
        {
            boosterTimeRemaining -= Time.deltaTime;
            if (boosterTimeRemaining <= 0)
            {
                DeactivateBooster();
            }
            
        }
        
        

        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * currentSpeed * Time.deltaTime * Vector3.right);
        
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
            UIBoosterManager.Instance.HideBooster();
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            currentSpeed = onIceSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentSpeed = speed;
    }

    public void ActivateBooster(float boostSpeed, float duration)
    {
        currentSpeed = boostSpeed;
        isBoosted = true;
        boosterTimeRemaining = duration;
        
        MoveBack[] movingObjects = FindObjectsByType<MoveBack>(FindObjectsSortMode.None);
        foreach (MoveBack obj in movingObjects)
        {
            obj.SetSpeed(boostSpeed);
        }
        
        UIBoosterManager.Instance.ShowBooster(duration);
    }

    private void DeactivateBooster()
    {
        currentSpeed = speed;
        isBoosted = false;
        
        MoveBack[] movingObjects = FindObjectsByType<MoveBack>(FindObjectsSortMode.None);
        foreach (MoveBack obj in movingObjects)
        {
            obj.ResetSpeed();
        }
        
        UIBoosterManager.Instance.HideBooster();
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
