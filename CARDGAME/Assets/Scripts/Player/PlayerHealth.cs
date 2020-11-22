using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] int maxHealth = 10;
    [SerializeField] int _currentHealth;
    [SerializeField] Slider healthBar;
    [SerializeField] Text healthText;
    [SerializeField] GameObject loseScreen;

    [SerializeField] int enemyDamage;
    [SerializeField] int monsterHeal;

    public Creature monster;


    public int decidingnumber;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = maxHealth;
        _currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = _currentHealth + " / 10";
        healthBar.value = _currentHealth;


    }


    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log("Took damage. Remaining health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            loseScreen.SetActive(true);
        }
    }

    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;

        if(_currentHealth >= maxHealth)
        {
            _currentHealth = maxHealth;
        }

    }

    public void roulette()
    {
        decidingnumber = Random.Range(1, 8);
        if(decidingnumber <= 9)
        {
            TakeDamage(enemyDamage);
        }
        else{
            monster.EnemyHeal(monsterHeal);
        }
    }

}
