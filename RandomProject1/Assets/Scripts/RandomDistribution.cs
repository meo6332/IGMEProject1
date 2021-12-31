using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDistribution : MonoBehaviour
{

    /**
     * The boxes need to get generated from 200 to 200 in 
     * the x and z axis.  The y axis isn't randomly generated,
     * but instead is based on the value. 
     * 
     */

    // This is the object to be distributed over the terrain
    [SerializeField]
    GameObject crate;

    // The terrain that I'm generating objects on top of
    [SerializeField]
    Terrain currentTerrain;


    private float xMax = 200.0f;
    private float zMax = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        // distributeOverTerrain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void distributeOverTerrain()
    {
        // The amount of objects to generate
        int genAmount = Random.Range(30, 51);

        // Loop through generating 30 to 50 objects over the terrain
        for(int i = 0 ; i < genAmount; i++)
        {
            // Generate the x and z values for this object, and make a Vector3 from those
            float xVal = Random.Range(0.0f, xMax);
            float zVal = Random.Range(0.0f, zMax);

            Vector3 currentVector = new Vector3(xVal, 0.0f, zVal);

            // Now find out the terrain's height at this new position
            currentVector.y = currentTerrain.SampleHeight(currentVector); // + currentTerrain.GetPosition().y;
            currentVector.y += 0.8f;

            // Have the proper position, now just generate the object there
            Instantiate(crate, currentVector, Quaternion.identity);

        }
    }

}
