using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeDistribution : MonoBehaviour
{

    // The object to be used as horde members
    [SerializeField]
    GameObject warrior;

    // The terrain that I'm generating objects on top of
    [SerializeField]
    Terrain currentTerrain;

    // These next values are the bounds for the placement of the horde 
    private float xMin = 80.0f;
    private float xMax = 120.0f;
    private float zMin = 70.0f;
    private float zMax = 130.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateHorde()
    {
        // Generate the amount of objects to generate
        int genAmount = Random.Range(50, 101);

        // Loop through the generation of each object
        for(int i = 0; i < genAmount; i++)
        {
            // Generate the x value first, as that isn't the part that's weighted 
            float xVal = Random.Range(xMin, xMax);

            // Generate a randon num from 0 to 1 to determine 
            float zVal = -1.0f;
            float weightVal = Random.Range(0.0f, 1.0f);
            

            // 0.1, 0.2, 0.3, 0.4 are the sections for these for weights
            // Hard coding these range values as they should never change
            if (weightVal < 0.5)
            {
                // Most abundant part of the horde, clustered around the front
                zVal = Random.Range(124.0f, zMax);
            }
            else if (weightVal < 0.75)
            {
                zVal = Random.Range(112.0f, 124.0f);
            }
            else if (weightVal < 0.90)
            {
                zVal = Random.Range(94.0f, 112.0f);
            }
            else
            {
                zVal = Random.Range(94.0f, zMin);
            }

            // Weighted Z value is generated, now make a Vector 3 based on it
            Vector3 currentVector = new Vector3(xVal, 0.0f, zVal);

            // Now find out the terrain's height at this new position
            currentVector.y = currentTerrain.SampleHeight(currentVector); 
            currentVector.y += 0.4f;

            Instantiate(warrior, currentVector, Quaternion.identity);

        }
    }
}
