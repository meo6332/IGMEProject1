using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TerrainGeneration class
// Placed on a terrain game object
// Generates a Perlin noise-based heightmap
[RequireComponent(typeof(TerrainCollider))]
public class TerrainGeneration : MonoBehaviour
{

	private TerrainData myTerrainData;
	[Tooltip("The size of the terrain")]
	public Vector3 worldSize = new Vector3(200, 50, 200);
	[Tooltip("Number of vertices along X and Z axes")]
	[Min(1)]
	public int resolution = 129;
	float[,] heightArray;

	// Will be used to modify perlin noise
	public float ModifyPerlinXValue;
	public float ModifyPerlinYValue;


	// The object with the random spawning scripts
	[SerializeField]
	GameObject generatorObject;

	void Start()
	{
		myTerrainData = gameObject.GetComponent<TerrainCollider>().terrainData;
		myTerrainData.size = worldSize;
		myTerrainData.heightmapResolution = resolution;

		heightArray = new float[resolution, resolution];

		// Fill the height array with values!
		// Uncomment the Ramp and Perlin methods to test them out!
		//Flat(0.0f);
		//Ramp();
		Perlin();

		// Assign values from heightArray into the terrain object's heightmap
		myTerrainData.SetHeights(0, 0, heightArray);

		// Now call the functions to generate what I need to on the terrain
		RandomDistribution first = generatorObject.GetComponent<RandomDistribution>();
		first.distributeOverTerrain();

		// Call the horde function 
		HordeDistribution second = generatorObject.GetComponent<HordeDistribution>();
		second.generateHorde();

		// Call the gaussian function
		PerlinDistribution third = generatorObject.GetComponent<PerlinDistribution>();
		third.gaussianGenerate();
	}


	void Update()
	{

	}

	/// <summary>
	/// Flat()
	/// Assigns heightArray identical values
	/// </summary>
	void Flat(float value)
	{
		// Fill heightArray with 1's
		for (int i = 0; i < resolution; i++)
		{
			for (int j = 0; j < resolution; j++)
			{
				heightArray[i, j] = value;
			}
		}
	}


	/// <summary>
	/// Ramp()
	/// Assigns heightsArray values that form a linear ramp
	/// </summary>
	void Ramp()
	{
		float rampVal = resolution;

		// Fill heightArray with linear values
		for (int i = 0; i < resolution; i++)
		{
			// Should result in a changing value each time, want to either
			// put this in inner loop or not
			float arrayVal = rampVal / resolution;

			for (int j = 0; j < resolution; j++)
			{

				heightArray[j, i] = arrayVal;
			}

			// Incriment the rampVal
			rampVal--;

		}

	}

	/// <summary>
	/// Perlin()
	/// Assigns heightsArray values using Perlin noise
	/// </summary>
	void Perlin()
	{

		// Set up the xCoord and yCoord's starting values
		float xCoord = 0.0f;
		float yCoord = 0.0f;
		float perlinValue;

		float xOffset = Random.Range(0.0f, 0.4f);
		float yOffset = Random.Range(0.0f, 0.4f);
		// xCoord = xCoord + xOffset;
		yCoord = yCoord + yOffset;


		// Fill heightArray with Perlin-based values
		for (int i = 0; i < resolution; i++)
		{
			for (int j = 0; j < resolution; j++)
			{
				// Generate the Perlin Noise Value
				perlinValue = Mathf.PerlinNoise(xCoord, yCoord);

				// Update the Perlin Noise coordinates
				xCoord = xCoord + ModifyPerlinXValue;


				// Set the height map's value
				heightArray[i, j] = perlinValue;

			}

			yCoord = yCoord + ModifyPerlinYValue;

			xCoord = 0.0f;

		}

	}
}
