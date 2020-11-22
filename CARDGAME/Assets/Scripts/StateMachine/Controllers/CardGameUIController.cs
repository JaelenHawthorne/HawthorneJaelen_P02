using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class CardGameUIController : MonoBehaviour
{
    public int decidingNum;
    [SerializeField] Text _enemyThinkingTextUI = null;
    public PlayerHealth playerHealth;
    public Creature enemy;

    [SerializeField] int enemyDamge = 2;
    [SerializeField] int enemyHeal = 2;

    private void OnEnable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded += OnEnemyTurnEnded;
    }

    private void OnDisable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
    }

    // Start is called before the first frame update
    void Start()
    {
        // make sure text is disabled on start
        _enemyThinkingTextUI.gameObject.SetActive(false);
        
    }

    void OnEnemyTurnBegan()
    {
        _enemyThinkingTextUI.gameObject.SetActive(true);
        decidingNum = Random.Range(1, 10);
        if(decidingNum <= 5)
        {
            playerHealth.TakeDamage(enemyDamge);
        }
        else
        {
            enemy.EnemyHeal(enemyHeal);
        }

    }

    void OnEnemyTurnEnded()
    {
        _enemyThinkingTextUI.gameObject.SetActive(false);
    }
}
