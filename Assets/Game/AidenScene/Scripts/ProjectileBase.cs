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
		if (other.CompareTag("Enemy") && pierce > 0 && other.GetComponent<Bloon>())
		{
			if (!other.GetComponent<Bloon>().alreadyHit)
			{
				other.GetComponent<Bloon>().ApplyDamage(damage);
				pierce--;
			}
		}
	}
}
