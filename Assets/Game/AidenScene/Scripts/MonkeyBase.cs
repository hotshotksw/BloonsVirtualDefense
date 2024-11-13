using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonkeyBase : MonoBehaviour
{
	[SerializeField] GameObject projectilePrefab;
	[SerializeField] Transform projectileInstSpot;
	[SerializeField] float fireRate;
	private float ogFireRate;
	[SerializeField] float projectileSpeed;
	[SerializeField] float range;

	private RaycastHit hit;
	private GameObject enemy;
	private GameObject bullet;

	private void Start()
	{
		ogFireRate = fireRate;
	}

	private void Update()
	{
		if (enemy != null)
		{
			transform.LookAt(enemy.transform);
		}

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

	private void FixedUpdate()
	{
		Ray ray = new(transform.position, transform.forward);
		Physics.Raycast(ray, out hit, range);

		for (int i = 0; i < SceneManager.GetActiveScene().GetRootGameObjects().Length; i++)
		{
			if (SceneManager.GetActiveScene().GetRootGameObjects().ElementAt(i).CompareTag("Enemy"))
			{
				enemy = SceneManager.GetActiveScene().GetRootGameObjects().ElementAt(i);
				break;
			}
		}
	}

	private void Fire()
	{
		bullet = Instantiate(projectilePrefab, projectileInstSpot.position, projectileInstSpot.rotation);
		bullet.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1, 0, 0, 0.25f);
		Gizmos.DrawSphere(transform.position, range);
	}
}
