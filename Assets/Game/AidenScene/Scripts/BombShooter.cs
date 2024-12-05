using UnityEngine;

public class BombShooter : MonkeyBase
{

	[SerializeField] GameObject projectilePrefab;
	[SerializeField] Transform projectileInstSpot;
	[SerializeField] float fireRate;
	private float ogFireRate;
	[SerializeField] float projectileSpeed;
	public float projectileSpeedToUse;
	[SerializeField] float range;
	private float rangeToUse;

	// these will be private later, not now, just for testing
	[SerializeField] public bool biggerBombs;
	[SerializeField] public bool rocketLauncher;
	private bool doneRL;
	[SerializeField] public bool bloonMauler;
	[SerializeField] public bool massiveBombs;

	private GameObject bullet;

	private void Start()
	{
		ogFireRate = fireRate;
		rangeToUse = range;
		base.rangeBase = rangeToUse;
		projectileSpeedToUse = projectileSpeed;
	}

	protected override void Update()
	{
		base.Update();
		Upgrade();
		if (hit.collider != null)
		{
			if (hit.collider.CompareTag("Enemy") && fireRate <= 0)
			{
				Fire();
				fireRate = ogFireRate;
			}
		}

		if (fireRate > 0)
		{
			fireRate -= Time.deltaTime;
		}
		else if (fireRate <= 0)
		{
			fireRate = 0;
		}
	}

	protected override void FixedUpdate()
	{
		base.FixedUpdate();
		Ray ray = new(transform.position, transform.forward);
		Physics.Raycast(ray, out hit, rangeToUse);
	}

	private void Upgrade()
	{
		if (rocketLauncher && !doneRL)
		{
			projectileSpeedToUse = projectileSpeedToUse * 1.85f;
			ogFireRate = ogFireRate * 0.875f;
			rangeToUse = rangeToUse * 1.6f;
			base.rangeBase = rangeToUse;
			doneRL = true;
		}
	}

	private void Fire()
	{
		bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
		bullet.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeedToUse);
		if (biggerBombs) bullet.GetComponent<Bomb>().biggerBombs = true;
		if (bloonMauler) bullet.GetComponent<Bomb>().bloonMauler = true;
		if (massiveBombs) bullet.GetComponent<Bomb>().massiveBombs = true;
	}

	//private void OnTriggerEnter(Collider other)
	//{
	//	if (other.CompareTag("Enemy"))
	//	{
	//		Debug.Log("Enemy");
	//		enemy = other.gameObject;
	//		enemies.Add(enemy);
	//	}
	//}

	//private void OnTriggerExit(Collider other)
	//{
	//	if (other.CompareTag("Enemy"))
	//	{
	//		enemy = other.gameObject;
	//		enemies.Remove(enemy);
	//	}
	//}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1, 0, 0, 0.25f);
		Gizmos.DrawSphere(transform.position, rangeToUse);
	}
}
