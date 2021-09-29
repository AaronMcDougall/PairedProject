using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
	void OnEnable()
	{
		EventManager.DeathEvent += FireConfetti;
		
	}

	void OnDisable()
	{
		EventManager.DeathEvent -= FireConfetti;
		
	}


	void FireConfetti()
	{
		print("Works!");
		//this.GetComponent<ParticleSystem>().Play();
		//this.transform.rotation = Quaternion.Euler(0, 0, 90);
		//gameObject.GetComponent<Health>().transform.rotation = Quaternion.Euler(0, 0, 90);
	}
}
