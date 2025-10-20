using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public int enemyHealth;
    public int enemySpeed;
    public int enemyViewRange;
    public GameObject targetToFollow;

    void Start()
    {
        targetToFollow = GameObject.FindWithTag("Player");
        enemyHealthSlider.maxValue = enemyHealth;
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.value = enemyHealth;
    }

    void Update()
    {
        
    }

    public void DamageToEnemy()
    {
        
    }
}
