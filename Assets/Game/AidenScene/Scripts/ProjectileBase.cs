using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileBase : MonoBehaviour
{
	protected int damage;
	protected int pierce;
	protected float lifespan;

	protected virtual void Update()
	{
		lifespan -= Time.deltaTime;
		if (lifespan < 0) Destroy(gameObject);
		if (pierce <= 0) Destroy(gameObject);
	}

	protected virtual void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") && pierce > 0 && other.GetComponent<K_Bloon>())
		{
			if (!other.GetComponent<K_Bloon>().alreadyHit)
			{
				other.GetComponent<K_Bloon>().ApplyDamage(damage);
				pierce--;
			}
		}
	}
}
