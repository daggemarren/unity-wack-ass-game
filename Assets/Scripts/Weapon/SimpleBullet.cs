using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// The class definition for a projectile
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class SimpleBullet : MonoBehaviour
{
	/// <summary>
	/// Public fields
	/// </summary>
	public float m_Speed = 3140.0f;   // this is the projectile's speed
	public float m_Lifespan = 13f; // this is the projectile's lifespan (in seconds)

	/// <summary>
	/// Private fields
	/// </summary>
	private Rigidbody m_Rigidbody;

	/// <summary>
	/// Message that is called when the script instance is being loaded
	/// </summary>
	void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
		List<Color> colors = new List<Color>();
		colors.Add(Color.red);
		colors.Add(Color.blue);
		colors.Add(Color.green);
		colors.Add(Color.yellow);
		colors.Add(Color.black);

		System.Random randNum = new System.Random();
		int aRandomPos = randNum.Next(colors.Count);//Returns a nonnegative random number less than the specified maximum (colors.Count).

		Color currName = colors[aRandomPos];
		GetComponent<Renderer>().material.color = currName;
	}

	/// <summary>
	/// Message that is called before the first frame update
	/// </summary>
	void Start()
	{
		m_Rigidbody.AddForce(GameObject.FindWithTag("Player").transform.forward * m_Speed);
		Destroy(this.gameObject, m_Lifespan);
	}
}