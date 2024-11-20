using UnityEngine;

public class Bloon : MonoBehaviour
{
	public bool alreadyHit;
	[SerializeField] int health;

	private void Update()
	{
		if (health <= 0) Destroy(gameObject);
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
		health -= damage;
	}
}
