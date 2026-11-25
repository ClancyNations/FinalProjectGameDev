using System.Collections.Generic;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;


public enum DudeType
{
    normal,
    medic,
    wizard
}

public enum CardType
{
    dude,
    item,
    enemy
}

public enum PackType
{
    basic,
    fantasy
}

public class GameManager : MonoBehaviour
{
    
    public List<Card> allCards = new List<Card>();
    public List<Card> playerCards = new List<Card>();
    public List<Card> enemyCards = new List<Card>();
    public List<Card> basicPack = new List<Card>();
    public List<Card> fantasyPack = new List<Card>();
    public GameObject cardPrefab;
    public GameObject packPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateAllCardDeck();
        CreateBasicPackDeck();
        //OpenBasicPack();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            SpawnPack(PackType.basic);
        }
    }

    private void CreateAllCardDeck()
    {
        //for each card: allCards.Add(new Card(cardType, dudeType, hp, atk));
    }

    private void CreateBasicPackDeck()
    {
        Card normalCard = new Card();
        normalCard.SetUpCard(CardType.dude, DudeType.normal, 10, 10, this);
        for (int i = 0; i < 4; i++)
        {
            basicPack.Add(normalCard);
        }
        Card medicCard = new Card();
        medicCard.SetUpCard(CardType.dude, DudeType.medic, 15, 8, this);
        basicPack.Add(medicCard);
        Card wizardCard = new Card();
        wizardCard.SetUpCard(CardType.dude, DudeType.wizard, 8, 15, this);
        basicPack.Add(wizardCard);
    }

    public void OpenBasicPack()
    {
        for (int i = 0; i < 4; i++)
        {
            int randomI =  Random.Range(0, basicPack.Count);
            Card card = basicPack[randomI];
            Vector3 pos = new Vector3(i * 2, 5, 0);
            GameObject createdCard = Instantiate(cardPrefab, pos, Quaternion.identity);
            createdCard.GetComponent<Card>().SetUpCard(card);
            playerCards.Add(createdCard.GetComponent<Card>());
            Debug.Log(createdCard.GetComponent<Card>().hp);
        }
    }

    public void SpawnPack(PackType packType)
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = 0;
        
        Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(mousePos));
        if (hit != null && hit.GetComponent<Pack>() != null)
        {
            hit.GetComponent<Pack>().Open();
        }
        
        GameObject packGB =  Instantiate(packPrefab, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        Pack pack = packGB.GetComponent<Pack>();
        pack.gameManager = this;
        pack.packType = packType;
    }
}
