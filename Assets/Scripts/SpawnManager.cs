using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] obstaclePrefab;
    
    public float startDelay = 0.1f;
    public float repeatLate = 1f;
    
    private PlayerController playerController; // อ้างอิงถึง PlayerController เพื่อตรวจสอบว่าเกมจบหรือยัง
    void Start()
    {
        // ค้นหา "Car" PlayerController มาใช้
        playerController = GameObject.Find("Car").GetComponent<PlayerController>();
        
        InvokeRepeating("Spawn", startDelay, repeatLate);
    }

    void Spawn()
    {
        // ถ้าเกมจบแล้ว ให้หยุดการเกิดของสิ่งกีดขวาง
        if (playerController.isGameOver)
        {
            CancelInvoke("Spawn");
            return;
        }
        
        int randomIndex = Random.Range(0, obstaclePrefab.Length);
        Instantiate(obstaclePrefab[randomIndex], spawnPoint.position, obstaclePrefab[randomIndex].transform.rotation);
    }
}
