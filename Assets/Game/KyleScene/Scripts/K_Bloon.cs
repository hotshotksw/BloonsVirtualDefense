using UnityEngine;

public class K_Bloon : MonoBehaviour
{
    public float speed = 10f;
    public int hitPoints = 1;
    public int damage;
    public int rewardPoints = 1;
    private Transform target;
    private int waypointIndex = 0;

    public bool alreadyHit;

    void Start ()
    {
        target = Waypoints.points[0];
        damage = hitPoints;
    }

    void Update ()
    {
        
        
        if (hitPoints <= 0) 
        {
            GameObject.Find("GameManager").GetComponent<Player>().AddBananas(rewardPoints);
            Destroy(gameObject);
        }
        Vector3 dir = target.position - transform.position;
        dir = new Vector3(dir.x, 0, dir.z);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(target.position.x, target.position.z)) < 0.4f)
        {
            GetNextWaypoint();
        }
        
    }

    void GetNextWaypoint ()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
            target = Waypoints.points[waypointIndex];
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Projectile")) alreadyHit = false;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Projectile")) alreadyHit = false;
	}
	public void ApplyDamage(int damage)
	{
		hitPoints -= damage;
	}
}
