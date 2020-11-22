using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeckTester : MonoBehaviour
{
    [SerializeField] List<AbilityCardData> _abilityDeckConfig = new List<AbilityCardData>();
    [SerializeField] AbilityCardView _abilityCardView = null;
    Deck<AbilityCard> _abilityDeck = new Deck<AbilityCard>();
    Deck<AbilityCard> _abilityDiscard = new Deck<AbilityCard>();

    Deck<AbilityCard> _playerHand = new Deck<AbilityCard>();

    public Creature _creature;

    public GameObject card;

    public GameObject playCard;

    public AudioSource drawSound;
    public AudioSource playSound;

    public AudioSource attackSound;
    public AudioSource playerTurn;

    public GameObject Hand;
    public int numOfCardsInDeck;
    public PlayerHealth myPlayer;

    [SerializeField] int enemyDamage = 2;
    [SerializeField] int healAMount = 3;

    public GameObject enemyTxt;
    public GameObject playerTxt;


    //leen
    public LeanTweenType inType;
    public LeanTweenType outType;
    public UnityEvent onCompleteCallBack; 

    //


    public int decidingnum;

    private void SetupAbilityDeck()
    {
      foreach(AbilityCardData abilityData in _abilityDeckConfig)
        {
            AbilityCard newAbilityCard = new AbilityCard(abilityData);
            _abilityDeck.Add(newAbilityCard);
        }
        _abilityDeck.Shuffle();
    }

    private void Update()
    {
        Hand = GameObject.Find("Hand");


        if (Input.GetKeyDown(KeyCode.Q))
        {
            Draw();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PrintPlayerHand();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayTopCard();
            _creature.TakeDamage(4);
        }
    }

    private void Draw()
    {
        AbilityCard newCard = _abilityDeck.Draw(DeckPosition.Top);
        Debug.Log("Drew card: " + newCard.Name);
        _playerHand.Add(newCard, DeckPosition.Top);

        _abilityCardView.Display(newCard);

        LeanTween.moveX(card, 528, .3f).setLoopPingPong(1).setDelay(0.3f);
        drawSound.Play();

            if (_playerHand.Count == 0)
            {
                reShuffle();
            }
        }

    private void PrintPlayerHand()
    {
        for (int i = 0; i < _playerHand.Count; i++)
        {
            Debug.Log("Player Hand Card: " + _playerHand.GetCard(i).Name);
        }
    }

    void PlayTopCard()
    {
        LeanTween.scale(playCard, new Vector3(2, 2, 2), .5f).setLoopPingPong(1);
        playSound.Play();

        decidingnum = Random.Range(1, 10);
        AbilityCard targetCard = _playerHand.TopItem;
        targetCard.Play();
        //TODO consider expanding Remove to accept a deck position
        _playerHand.Remove(_playerHand.LastIndex);
        _abilityDiscard.Add(targetCard);
        Debug.Log("Card added to discard: " + targetCard.Name);
        
        if (decidingnum <= 7)
        {
            StartCoroutine(turnChange());
            myPlayer.TakeDamage(enemyDamage);
            
        }
        else
        {
            StartCoroutine(turnChange());
            _creature.EnemyHeal(healAMount);
            
        }
    }

    private void Start()
    {
        SetupAbilityDeck();
        
    }

    private void reShuffle()
    {
        
         _abilityDeck = new Deck<AbilityCard>();
        
    }

    public void drawCard()
    {
        Draw();
    }

    public void Play()
    {
        PlayTopCard();
    }

    IEnumerator turnChange()
    {
        attackSound.Play();
        enemyTxt.SetActive(true);
        playerTxt.SetActive(false);
        yield return new WaitForSeconds(2);
        enemyTxt.SetActive(false);
        playerTxt.SetActive(true);
        playerTurn.Play();
    }

}
