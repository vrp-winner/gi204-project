using UnityEngine;

public class Booster : MonoBehaviour
{
    public float boostSpeed = 20f;
    public float boostDuration = 5f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.ActivateBooster(boostSpeed, boostDuration);
                Destroy(gameObject);
            }
        }
    }
}