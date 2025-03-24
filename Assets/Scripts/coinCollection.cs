using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private int coin = 0;

    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) // เปลี่ยนมาใช้ Compare Tag แทนจะดีกว่า transform.tag
        {
            coin++;
            coinText.text = "Coin: " + coin;
            Destroy(other.gameObject);
        }
    }
}