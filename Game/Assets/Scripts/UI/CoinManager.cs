using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        coinText.text = "Coins: 0";
    }
    
    public void AddCoin(int amount)
    {
        gameManager.Coins += amount;
        coinText.text = "Coins: " + gameManager.Coins.ToString();
    }
}
