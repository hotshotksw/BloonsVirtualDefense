using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonkeyBase : MonoBehaviour
{
	protected RaycastHit hit;
	//protected GameObject enemy;
	public List<GameObject> enemies = new List<GameObject>();
	[NonSerialized] protected float rangeBase;

	protected virtual void Update()
	{
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
				break;
			}
		}
	}

	protected virtual void FixedUpdate()
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
