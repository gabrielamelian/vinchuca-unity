using UnityEngine;
using System.Collections;

public class Difficulty {
	
	/// <summary>
	/// Initial values for variables.
	/// </summary>
	public int initialMaxFleas = 1;
	public float initialPercentageSpawn = 60f;
	public float initialTimeBetweenSpawns = 0.8f;

	/// <summary>
	/// Time between difficulty changes.
	/// </summary>
	public float timeBetweenDifficulty = 10f;

	/// <summary>
	/// Upper limits of individual difficulty increases.
	/// </summary>
	public float maxPercentageSpawn = 80f;
	public float minTimeBetweenSpawns = 0.2f;

}

