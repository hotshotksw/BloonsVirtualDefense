using UnityEngine;

public class DartMonkey : MonkeyBase
{
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] Transform projectileInstSpot;
	[SerializeField] float fireRate;
	private float ogFireRate;
	[SerializeField] float projectileSpeed;
	private float projectileSpeedToUse;
	[SerializeField] float range;
	private float rangeToUse;

	// these will be private later, not now, just for testing
	[SerializeField] bool fasterFiring;
	private bool doneFR;
	[SerializeField] bool largerRange;
	private bool doneLR;
	[SerializeField] bool tripleDart;
	[SerializeField] public bool crossBow;
	private bool doneCB;

	private GameObject bullet;

	private void Start()
	{
		ogFireRate = fireRate;
		rangeToUse = range;
		projectileSpeedToUse = projectileSpeed;
	}

	protected override void Update()
	{
		if (enemy)
		{
			if ((Mathf.Abs(enemy.transform.position.x) + Mathf.Abs(enemy.transform.position.z)) - (Mathf.Abs(transform.position.x) + Mathf.Abs(transform.position.z)) < rangeToUse * 1.5f)
			{
				base.Update();
			}
		}
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
		if (fasterFiring && !doneFR)
		{
			ogFireRate = ogFireRate * 0.65f;
			doneFR = true;
		}

		if (crossBow && !doneCB)
		{
			projectileSpeedToUse = projectileSpeedToUse * 1.5f;
			rangeToUse = rangeToUse * 1.35f;
			ogFireRate = ogFireRate * 0.75f;
			doneCB = true;
		}

		if (largerRange && !doneLR)
		{
			rangeToUse = rangeToUse * 1.75f;
			doneLR = true;
		}
	}

	private void Fire()
	{
		bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
		bullet.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeedToUse);
		if (crossBow) bullet.GetComponent<Dart>().crossbow = true;
		if (tripleDart)
		{
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y + 15, 0);
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
			if (crossBow) bullet.GetComponent<Dart>().crossbow = true;
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y - 15, 0);
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
			if (crossBow) bullet.GetComponent<Dart>().crossbow = true;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1, 0, 0, 0.25f);
		Gizmos.DrawSphere(transform.position, rangeToUse);
	}
}