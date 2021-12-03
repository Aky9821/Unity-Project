using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinCollector : MonoBehaviour
{
    // Start is called before the first frame update
    private int coins = 0;
    [SerializeField] private Text CoinText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            CoinText.text = " Coins : " + coins;

        }
    }
}
