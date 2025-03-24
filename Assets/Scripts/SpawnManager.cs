using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] obstaclePrefab;
    public GameObject boosterPrefab;
    public GameObject coinPrefab;
    
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
        if (playerController.GetIsGameOver())
        {
            CancelInvoke("Spawn");
            return;
        }

        float randomValue = Random.value;
        int spawnIndex = Random.Range(0, spawnPoint.Length);

        if (randomValue < 0.1f)
        {
            Instantiate(boosterPrefab, spawnPoint[spawnIndex].position, Quaternion.identity);
        }
        else if (randomValue < 0.3f)
        {
            Instantiate(coinPrefab, spawnPoint[spawnIndex].position, Quaternion.identity);
        }
        else
        {
            // เลือกตำแหน่งเกิดสิ่งกีดขวาง 2 จุดแบบสุ่ม (จากทั้งหมด 3 จุด) และต้องไม่ซ้ำกัน
            int firstSpawnIndex = Random.Range(0, spawnPoint.Length);
            int secondSpawnIndex;
                    
            do
            {
                secondSpawnIndex = Random.Range(0, spawnPoint.Length);
            } while (secondSpawnIndex == firstSpawnIndex); // ห้ามซ้ำกับจุดแรก
                    
            // สุ่มเลือกอุปสรรคสำหรับตำแหน่งแรก
            int randomIndex1 = Random.Range(0, obstaclePrefab.Length);
                    
            // สุ่มเลือกอุปสรรคสำหรับตำแหน่งที่สอง
            int randomIndex2;
            if (randomValue < 0.1f) // มีโอกาส 10% ที่จะใช้สิ่งกีดขวางเดียวกันกับตำแหน่งแรก
            {
                randomIndex2 = randomIndex1;
            }
            else // อีก 90% ของกรณี สุ่มสิ่งกีดขวางใหม่
            {
                randomIndex2 = Random.Range(0, obstaclePrefab.Length);
            }
                    
            // สร้างสิ่งกีดขวางตัวแรกที่ตำแหน่งแรก
            Instantiate(obstaclePrefab[randomIndex1], spawnPoint[firstSpawnIndex].position, Quaternion.identity);
                    
            // สร้างสิ่งกีดขวางตัวที่สองที่ตำแหน่งที่สอง
            Instantiate(obstaclePrefab[randomIndex2], spawnPoint[secondSpawnIndex].position, Quaternion.identity);
        }
    }
}