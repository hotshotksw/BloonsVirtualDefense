using UnityEngine;

public class DartSpanwer : MonoBehaviour
{
   [SerializeField] GameObject prefb;
    GameObject unsedDart;

    void SpawnDart()
    {
        if (unsedDart.transform.position != transform.position)
        {
           unsedDart = Instantiate(prefb, this.transform);
            
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unsedDart = Instantiate(prefb, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        unsedDart.transform.position = transform.position;
        SpawnDart();
        
    }
}
