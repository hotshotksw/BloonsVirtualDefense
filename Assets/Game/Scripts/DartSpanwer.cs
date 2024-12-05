using UnityEngine;

public class DartSpanwer : MonoBehaviour
{
   [SerializeField] GameObject prefb;
    public Transform spawnPoint;
    

    public void SpawnDart()
    {
        
        Instantiate(prefb, spawnPoint.position,spawnPoint.rotation);
        
        
        Debug.Log("Working");
    }
    private void Awake()
    {
        
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = GameObject.Find("DartSpanwer").transform;
    }

    // Update is called once per frame
    void Update()
    {

    
        
    }
}
