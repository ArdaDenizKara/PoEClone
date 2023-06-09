using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person :MonoBehaviour
{
	#region Singleton

	public static Person instance;
	

	void Awake()
	{
		instance = this;
	}
	
	void Start()
	{
	}
	#endregion

}
