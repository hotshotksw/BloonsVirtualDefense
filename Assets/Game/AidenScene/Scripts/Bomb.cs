using UnityEngine;

public class Bomb : MonoBehaviour
{
	[SerializeField] float lifespan;

	[SerializeField] GameObject explosion;

	public bool biggerBombs;
	public bool bloonMauler;
	public bool massiveBombs;

	private bool alreadyExplode = false;

	private GameObject explodey;

	private void Update()
	{
		lifespan -= Time.deltaTime;
		if (lifespan < 0) Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy") && other.GetComponent<K_Bloon>() && !alreadyExplode)
		{
			explodey = Instantiate(explosion, transform);
			if (biggerBombs) explodey.GetComponent<Explosion>().biggerBombs = true;
			if (bloonMauler) explodey.GetComponent<Explosion>().bloonMauler = true;
			if (massiveBombs) explodey.GetComponent<Explosion>().massiveBombs = true;
			GetComponent<Rigidbody>().Sleep();
			lifespan = explodey.GetComponent<Explosion>().lifespan;
			alreadyExplode = true;
		}
	}
}
