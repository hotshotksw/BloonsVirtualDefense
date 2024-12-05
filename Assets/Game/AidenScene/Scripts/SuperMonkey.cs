using UnityEngine;

public class SuperMonkey : MonkeyBase
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
	[SerializeField] public bool largerRange;
	private bool doneLR;
	[SerializeField] public bool laserVision;
	private bool doneLV;
	[SerializeField] public bool plasmaBlasts;
	private bool donePB;
	[SerializeField] public bool sunGod;
	private bool doneSG;

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
		if (largerRange && !doneLR)
		{
			rangeToUse = rangeToUse * 1.75f;
			base.rangeBase = rangeToUse;
			doneLR = true;
		}

		if (laserVision && !doneLV)
		{
			ogFireRate = ogFireRate * 0.75f;
			doneLV = true;
		}

		if (plasmaBlasts && !donePB)
		{
			ogFireRate = ogFireRate * 0.75f;
			donePB = true;
		}

		if (sunGod && !doneSG)
		{
			projectileSpeedToUse = projectileSpeedToUse * 1.5f;
			rangeToUse = rangeToUse * 1.75f;
			base.rangeBase = rangeToUse;
			ogFireRate = ogFireRate * 0.5f;
			doneSG = true;
		}
	}

	private void Fire()
	{
		bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
		bullet.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeedToUse);
		if (laserVision) bullet.GetComponent<SuperMonkeyDart>().laserBlasts = true;
		if (plasmaBlasts) bullet.GetComponent<SuperMonkeyDart>().plasmaVision = true;
		if (sunGod) bullet.GetComponent<SuperMonkeyDart>().sunGod = true;
		if (sunGod)
		{
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y + 7.5f, 0);
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
			if (sunGod) bullet.GetComponent<SuperMonkeyDart>().sunGod = true;
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y - 7.5f, 0);
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
			if (sunGod) bullet.GetComponent<SuperMonkeyDart>().sunGod = true;
		}
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
