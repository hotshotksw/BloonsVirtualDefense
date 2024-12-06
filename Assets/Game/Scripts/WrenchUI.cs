using UnityEngine;

public class WrenchUI : MonoBehaviour
{
    GameObject ui;
    Transform wrenchPostion;
    bool isHeld;

    public void InUse()
    {
         isHeld = true;
        ui.gameObject.SetActive(true);
    }

    public void NotUsed()
    {
        isHeld = false;
        ui.gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wrenchPostion = GameObject.Find("WrenchBelt").transform;
        ui = GameObject.Find("MonkeyUI");
    }

    // Update is called once per frame
    void Update()
    {

        if (!isHeld)
        {
            this.transform.position = wrenchPostion.position;
        }

       
       
    }
}
