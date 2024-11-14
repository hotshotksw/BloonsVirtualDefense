using UnityEngine;

public class Bloon : MonoBehaviour
{
	public bool alreadyHit;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Projectile")) alreadyHit = false;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Projectile")) alreadyHit = false;
	}
}
