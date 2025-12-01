using System;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealth.fillAmount = playerHealth.CurrentHealth / 10;
    }

    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.CurrentHealth / 10;
    }
}
