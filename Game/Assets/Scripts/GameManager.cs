using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Coins { get; set; }

    private void Awake()
    {
        Time.timeScale = 1f;
        Coins = 0;
    }
}