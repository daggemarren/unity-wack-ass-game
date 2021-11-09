using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject enemy;
	public float xPos; 
	public float zPos;
	public float yPos;
	public int enemyCount;

	IEnumerator EnemyDrop(Transform spawnBoxPosition)
	{
		while (enemyCount < 100)
		{
			Instantiate(enemy, new Vector3(spawnBoxPosition.position.x, 28.0f, spawnBoxPosition.position.z), Quaternion.identity);
			yield return new WaitForSeconds(0.4f);
			enemyCount++;
		}
	}

	void Start()
	{
		StartCoroutine(EnemyDrop(transform));
	}
}
