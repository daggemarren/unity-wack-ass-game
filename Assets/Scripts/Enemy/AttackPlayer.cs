using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private Transform player;
	private float hp = 3.0f;

	// Update is called once per frame
	void FixedUpdate()
	{
		player = GameObject.FindWithTag("Player").transform;
		if (!player)
		{
			return;
		}
		transform.position = Vector3.MoveTowards(transform.position, player.position, .1f);
	}

	void Update() {
		if(hp <= 0) {
			Destroy(this.gameObject);
		} 

		if(hp > 5 && hp < 10) {
			GetComponent<Renderer>().material.color = Color.blue;
		}

		if(hp < 5) {
			GetComponent<Renderer>().material.color = Color.yellow;
		}

		if( hp < 2) {
			GetComponent<Renderer>().material.color = Color.red;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "SimpleBullet")
		{
			hp -= 1.0f;
		}
	}
}
