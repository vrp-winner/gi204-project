using TMPro;
using UnityEngine;

public class coinCollection : MonoBehaviour
{
    private int Coin = 0;

    public TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Coin")
        {
            Coin++;
            coinText.text = "Coin: " + Coin.ToString();
            Debug.Log(Coin);
            Destroy(other.gameObject);


        }
    }
}
