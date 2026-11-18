using UnityEngine;
using System.Collections;

public class Card :  MonoBehaviour
{

    public CardType cardType;
    public DudeType dudeType;
    public int hp;
    public int atk;
    public GameManager gameManager;
    

    public void SetUpCard(Card baseCard)
    {
        this.cardType = baseCard.cardType;
        this.dudeType = baseCard.dudeType;
        this.hp = baseCard.hp;
        this.atk = baseCard.atk;
        //this.sprite = baseCard.GetDudeSprite();
    }

    public void SetUpCard(CardType cardType, DudeType dudeType, int hp, int atk)
    {
        this.cardType = cardType;
        this.dudeType = dudeType;
        this.hp = hp;
        this.atk = atk;
        //this.sprite = baseCard.GetDudeSprite();
    }
    
    public Sprite GetDudeSprite()
    {
        
        switch (dudeType)
        {
            case DudeType.normal:
                //return gameManager.normalDudeSprite;
                break;
            case DudeType.medic:
                break;
            case DudeType.wizard:
                break;
        }

        return null;
    }
    
}
