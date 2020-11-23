using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Creature : MonoBehaviour, ITargetable, IDamageable
{
    [SerializeField] int maxHealth = 10;
    [SerializeField] int _currentHealth;
    [SerializeField] Slider healthBar;
    [SerializeField] Text healthText;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;

    public int score;

    public PlayerHealth playerLife;

    public int playerHealing = 4;

    public Text HighScore;

    [SerializeField] Text CountDown;
    public int timer = 40;

    void Start()
    {
        
        healthBar.maxValue = maxHealth;
        _currentHealth = maxHealth;
        HighScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highScore", 0).ToString();
        StartCoroutine(CountDownToEnd());
    }

    IEnumerator CountDownToEnd()
    {
        while(timer  > 0)
        {
            CountDown.text = timer.ToString();

            yield return new WaitForSeconds(1f);

            timer--;
        }

        if(_currentHealth > 0 && timer == 0)
        {
            loseScreen.SetActive(true);
        }

    }

    void Update()
    {
        healthText.text = _currentHealth + " / 10";
        healthBar.value = _currentHealth;

        if(_currentHealth <= 0)
        {
            winScreen.SetActive(true);
            StopCoroutine(CountDownToEnd());
        }
        
    }

    public void Kill()
    {
        Debug.Log("Killed the creature!");
        score += 1;
        PlayerPrefs.SetInt("highScore", score);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        Debug.Log("Took damage. Remaining health: " + _currentHealth);

        PlayerPrefs.SetInt("Enemey Health", _currentHealth);

        if(_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void healPlayer(int heal)
    {
        heal = playerHealing;
        playerLife.Heal(heal);
    }


  public void Target()
    {
        Debug.Log("Creature has been targeted.");
    }

    public void EnemyHeal(int healAMount)
    {
        _currentHealth += healAMount;
        if(_currentHealth >= maxHealth)
        {
            _currentHealth = maxHealth;
        }
    }
}





    
     

    



   
