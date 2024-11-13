using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class ProjectileBase : MonoBehaviour
{
    [SerializeField] int damage;
	[SerializeField] int pierce;
    [SerializeField] float lifespan;

	private void Update()
	{
		lifespan -= Time.deltaTime;
		if (lifespan < 0) Destroy(gameObject);
	}
}
