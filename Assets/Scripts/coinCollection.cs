using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private int coin = 0;

    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coin++;
            coinText.text = "Coin: " + coin;
            
            Rigidbody coinRB = other.GetComponent<Rigidbody>();
            if (coinRB != null)
            {
                Vector3 angularVelocity = new Vector3(0, 20, 0);
                Vector3 linearVelocity = new Vector3(0, 2, 0);
                coinRB.angularVelocity = angularVelocity;
                coinRB.AddForce(linearVelocity, ForceMode.Impulse);
            }
                
            Destroy(other.gameObject, 1f);
        }
    }
}