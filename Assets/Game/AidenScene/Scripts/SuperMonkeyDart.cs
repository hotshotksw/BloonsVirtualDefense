using UnityEngine;

public class SuperMonkeyDart : ProjectileBase
{
	[SerializeField] int Damage;
	[SerializeField] float Lifespan;
	[SerializeField] int Pierce;

	public bool laserBlasts;
	public bool plasmaVision;
	public bool sunGod;
	private bool doneLB;
	private bool donePV;
	private bool doneSG;

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
		if (laserBlasts && !doneLB)
		{
			base.damage = 2;
			base.pierce = 2;
			doneLB = true;
		}
		if (plasmaVision && !donePV)
		{
			base.damage = 5;
			base.pierce = 10;
			donePV = true;
		}
		if (sunGod && !doneSG)
		{
			base.damage = 20;
			base.pierce = 30;
			doneSG = true;
		}
		base.Update();
	}
}
