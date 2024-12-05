using UnityEngine;

public class PlayerDart : Dart
{
    public bool grabbed = false;
    DartSpanwer dartSpanwer;
    Rigidbody rb;


    //Called in interactable events
    public void Grabbed()
    {
        grabbed = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!grabbed)
        {
            transform.position = dartSpanwer.spawnPoint.position;
        }
        else
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
        base.Update();
        
    }
    private void Start()
    {
        dartSpanwer = gameObject.GetComponent<DartSpanwer>();
        rb = gameObject.GetComponent<Rigidbody>();
        lifespan = 1000;
        pierce = 1;
    }
}
