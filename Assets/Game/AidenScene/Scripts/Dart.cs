using UnityEngine;

public class Dart : ProjectileBase
{
	[SerializeField] int Damage;
	[SerializeField] float Lifespan;
	[SerializeField] int Pierce;

	public bool crossbow;
	private bool doneCB;

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
		if (crossbow && !doneCB)
		{
			base.damage = 5;
			base.pierce = 5;
			doneCB = true;
		}
		base.Update();
	}
}
