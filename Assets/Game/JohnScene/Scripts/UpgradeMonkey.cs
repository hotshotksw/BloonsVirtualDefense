using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMonkey : MonoBehaviour
{
    [SerializeField] DartMonkey monkey;
    [SerializeField] Player player;
    [SerializeField] GameObject upgradeUI;
    [SerializeField] TMP_Text monkeyNameText;
    [SerializeField] TMP_Text monkeyUpgradePriceText;
    [SerializeField] TMP_Text monkeyUpgradeButtonText;
    [SerializeField] Image monkeyIconImage;
    [SerializeField] int upgradePrice = 200;
    [SerializeField] int upgradeCount = 0;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.position = new Vector3(monkey.transform.position.x, monkey.transform.position.y - 0.25f, monkey.transform.position.z - 1.5f);
        rectTransform.rotation = Quaternion.Euler(50, 0, 0) ;
        monkeyIconImage.sprite = monkey.icon;
        monkeyNameText.text = monkey.monkeyName;
    }
    private void Update()
    {
        //monkeyUpgradePriceText.text = upgradePrice;
        if (upgradeCount > 4) 
        {
            monkeyUpgradeButtonText.text = "Fully Upgraded!";
            
        }
    }

    public void OnUpgradePress()
    {
        if (upgradeCount < 5)
        {

            if (player.Bananas >= upgradePrice)
            {
                player.RemoveBananas(upgradePrice);
                switch (upgradeCount)
                {
                    case 0:
                        monkey.fasterFiring = true;
                        break;
                    case 1:
                        monkey.largerRange = true;
                        break;
                    case 3:
                        monkey.tripleDart = true;
                        break;
                    case 4:
                        monkey.crossBow = true;
                        break;
                }
                upgradeCount++;

            }
        }
        
    }



}
