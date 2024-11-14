using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonkeyBase : MonoBehaviour
{
	protected RaycastHit hit;
	private GameObject enemy;

	protected virtual void Update()
	{
		if (enemy != null)
		{
			transform.LookAt(enemy.transform);
		}		
	}

	protected virtual void FixedUpdate()
	{
		for (int i = 0; i < SceneManager.GetActiveScene().GetRootGameObjects().Length; i++)
		{
			if (SceneManager.GetActiveScene().GetRootGameObjects().ElementAt(i).CompareTag("Enemy"))
			{
				enemy = SceneManager.GetActiveScene().GetRootGameObjects().ElementAt(i);
				break;
			}
		}
	}
}
