using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shuriken : ProjectileBase
{
	[SerializeField] int Damage;
	[SerializeField] float Lifespan;
	[SerializeField] int Pierce;

	public bool sharperShuriken;
	private bool doneSS;
	public bool grandmaster;
	private bool donegm;

	public List<GameObject> enemies = new List<GameObject>();
	public float rangeBase;

	private void Start()
	{
		base.damage = Damage;
		base.lifespan = Lifespan;
		base.pierce = Pierce;
	}


	protected override void OnTriggerEnter(Collider other)
	{
		base.OnTriggerEnter(other);
	}

	protected override void Update()
	{
		if ( sharperShuriken && !doneSS && !grandmaster)
		{
			base.pierce = 7;
			base.lifespan = 1.75f;
			doneSS = true;
		} else if (grandmaster && !donegm)
		{
			base.pierce = 20;
			base.damage = 2;
			base.lifespan = 2.25f;
			donegm = true;
		}
		for (int i = 0; i < enemies.Count; i++)
		{
			if (enemies.ElementAt(i).IsDestroyed())
			{
				enemies.RemoveAt(i);
			}
			else if (Mathf.Abs(transform.position.x - enemies.ElementAt(i).transform.position.x) +
				Mathf.Abs(transform.position.z - enemies.ElementAt(i).transform.position.z) < rangeBase * 1.5f)
			{
				transform.LookAt(enemies.ElementAt(i).transform);
				GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 250);
				break;
			}
		}

		base.Update();
	}

	private void FixedUpdate()
	{

		for (int i = 0; i < SceneManager.GetActiveScene().GetRootGameObjects().Length; i++)
		{
			if (SceneManager.GetActiveScene().GetRootGameObjects().ElementAt(i).CompareTag("Enemy"))
			{
				if (!enemies.Contains(SceneManager.GetActiveScene().GetRootGameObjects().ElementAt(i)))
				{
					enemies.Add(SceneManager.GetActiveScene().GetRootGameObjects().ElementAt(i));
				}
			}
		}
	}
}
