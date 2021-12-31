using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinDistribution : MonoBehaviour
{
    // These are the bounds of where the skeletons are generating 
    private float xMin = 85.0f;
    // private float xMax = 115.0f;

    // Will be used to modify perlin noise
    public float ModifyPerlinXValue;
    public float ModifyPerlinYValue;

    // The object to be modified and to be scaled
    [SerializeField]
    GameObject skeleton;

    [SerializeField]
    Terrain currentTerrain;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gaussianGenerate()
    {
        // Unlike the last few, for this I need to generate each of the scales using Gaussian
        // But the distance should be constant between them, least for where they're iterated
        float zPos = 140.0f;
        float xPos = xMin;
        int spacing = 3;

        // I only need 2 because the x and z scales should be the same
        float perlinX = 0.0f;
        float perlinY = 0.0f;
        // Value used for scaling x and z
        float perlinXValue;
        // Value used for scaling y
        float perlinYValue;

        float xOffset = Random.Range(0.0f, 0.5f);
        float yOffset = Random.Range(0.0f, 3.0f);
        perlinX = perlinX + xOffset;
        perlinY = perlinY + yOffset;

        // Used for randomly adjusting the Z position
        float posOffset;

        Vector3 skelePosition = new Vector3(xPos, 0.0f, zPos);

        GameObject thisSkele;


        // Start the outer loop.
        for (int i = 0; i <= 8; i++)
        {
            // Create the new position for the next object to be made
            posOffset = Random.Range(-2.0f, 2.0f);
            float currentZPos = zPos + posOffset;

            Vector3 newSkeleVector = new Vector3(xPos, 0.0f, currentZPos);

            // Get the current terrain's height at the position
            newSkeleVector.y = currentTerrain.SampleHeight(newSkeleVector);
            newSkeleVector.y += 0.4f;

            // Everything I need for the vector is done, now just deal with the scaling

            thisSkele = (GameObject) Instantiate(skeleton, newSkeleVector, Quaternion.identity);

            // First generate the two perlin values needed for scaling
            perlinXValue = Mathf.PerlinNoise(perlinX, perlinY);
            perlinYValue = Mathf.PerlinNoise(perlinX, perlinY);

            // Iterate the perlin values for x and y
            perlinX += ModifyPerlinXValue;
            perlinY += ModifyPerlinYValue;


            Debug.LogFormat("The X value for the perlin generation in skele {0} is: {1}", i, perlinXValue);
            Debug.LogFormat("The Y value for the perlin generation in skele {0} is: {1}\n", i, perlinYValue);

            // Perform the transformations for the scale
            Vector3 xScaleModifier = new Vector3(perlinXValue * 2.5f, 0.0f, perlinXValue * 2.0f);
            Vector3 yScaleModifier = new Vector3(0.0f, perlinYValue * 2.0f, 0.0f);
            thisSkele.transform.localScale += xScaleModifier;
            thisSkele.transform.localScale += yScaleModifier;

            // Move to the next position 
            xPos = xPos + spacing;
        } 


    }
}
