using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float pierce;
    [SerializeField] public float lifespan;
	[SerializeField] float explosionRadius;

	public bool biggerBombs;
	private bool bb;
	public bool bloonMauler;
	private bool bm;
	public bool massiveBombs;
	private bool mb;

	private void Start()
	{
		GetComponent<SphereCollider>().radius = explosionRadius;
	}

	protected virtual void Update()
	{
		lifespan -= Time.deltaTime;
		if (biggerBombs && !bloonMauler && !massiveBombs && !bb)
		{
			pierce = 20;
			explosionRadius *= 1.5f;
			GetComponent<SphereCollider>().radius = explosionRadius;
			bb = true;
		}
		else if (bloonMauler && !massiveBombs && !bm)
		{
			pierce = 65;
			explosionRadius *= 1.6f;
			GetComponent<SphereCollider>().radius = explosionRadius;
			damage = 10;
			bm = true;
		}
		else if (massiveBombs && !mb)
		{
			pierce = 150;
			explosionRadius *= 3.25f;
			GetComponent<SphereCollider>().radius = explosionRadius;
			damage = 20;
			mb = true;
		}
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
