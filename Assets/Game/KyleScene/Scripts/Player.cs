using UnityEngine;

public class Player : MonoBehaviour
{
    private int bananas = 100;
    public int Bananas
    {
        get { return bananas; }
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
}
