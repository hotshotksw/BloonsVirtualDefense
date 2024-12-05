using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private int bananas = 100;
    [SerializeField] private int health = 100;
    [SerializeField] TMP_Text Moneytext;
    [SerializeField] TMP_Text Healthtext;
    public int Bananas
    {
        get { return bananas; }
    }
    void Update()
    {
        Moneytext.text = "$" + bananas;
        Healthtext.text = health+"";
    }
    public void AddBananas(int amount)
    {
        bananas += amount;
        
        print(bananas);
    }

    public void RemoveBananas(int amount)
    {
        bananas -= amount;
        if (bananas < 0)
        {
            bananas = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        print(health);
    }
}
