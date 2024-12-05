using UnityEngine;

public class NinjaMonkey : MonkeyBase
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
	[SerializeField] public bool sharperShurikens;
	[SerializeField] public bool ninjaDiscipline;
	private bool doneND;
	[SerializeField] public bool doubleShot;
	[SerializeField] public bool grandmaster;
	private bool doneGM;

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
		if (ninjaDiscipline && !doneND)
		{
			ogFireRate = ogFireRate * 0.5f;
			rangeToUse = rangeToUse * 1.15f;
			base.rangeBase = rangeToUse;
			doneND = true;
		}

		if (grandmaster && !doneGM)
		{
			ogFireRate = ogFireRate * 0.5f;
			doneGM = true;
		}
	}

	private void Fire()
	{
		if (!doubleShot && !grandmaster)
		{
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeedToUse);
			bullet.GetComponent<Shuriken>().rangeBase = rangeToUse;
			if (sharperShurikens && !grandmaster) bullet.GetComponent<Shuriken>().sharperShuriken = true;
		}
		if (doubleShot && !grandmaster)
		{
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Shuriken>().sharperShuriken = true;
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y + 15, 0);
			bullet.GetComponent<Shuriken>().rangeBase = rangeToUse;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Shuriken>().sharperShuriken = true;
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y - 15, 0);
			bullet.GetComponent<Shuriken>().rangeBase = rangeToUse;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
		}
		else if (grandmaster)
		{
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Shuriken>().grandmaster = true;
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y + 5, 0);
			bullet.GetComponent<Shuriken>().rangeBase = rangeToUse;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Shuriken>().grandmaster = true;
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y - 5, 0);
			bullet.GetComponent<Shuriken>().rangeBase = rangeToUse;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Shuriken>().grandmaster = true;
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y + 10, 0);
			bullet.GetComponent<Shuriken>().rangeBase = rangeToUse;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Shuriken>().grandmaster = true;
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y - 10, 0);
			bullet.GetComponent<Shuriken>().rangeBase = rangeToUse;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Shuriken>().grandmaster = true;
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y + 15, 0);
			bullet.GetComponent<Shuriken>().rangeBase = rangeToUse;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
			bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
			bullet.GetComponent<Shuriken>().grandmaster = true;
			bullet.GetComponent<Transform>().eulerAngles = new Vector3(0, bullet.GetComponent<Transform>().eulerAngles.y - 15, 0);
			bullet.GetComponent<Shuriken>().rangeBase = rangeToUse;
			bullet.GetComponent<Rigidbody>().AddForce(bullet.GetComponent<Transform>().forward * projectileSpeedToUse);
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
