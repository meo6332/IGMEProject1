using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{

    [SerializeField]
    List<GameObject> cameras = new List<GameObject>();

    [SerializeField]
    int activeIndex;

    [SerializeField]
    Text activeCameraLabel;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject cam in cameras)
        {
            cam.SetActive(false);
        }

        ChangeCameraByIndex(activeIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCameraByIndex(int index)
    {
        // Changes camera based on buttons that get pushed 
        Debug.LogFormat("Change to camera: {0}", index);

        if (index >= 0 && index <= 5)
        {
            cameras[activeIndex].SetActive(false);

            cameras[index].SetActive(true);

            activeIndex = index;

            // Set the new camera label 
            activeCameraLabel.text = cameras[index].name;
        }
        else
        {
            Debug.LogFormat("Index {0} was out of bounds, remaining at index {1}.", index, activeIndex);
        }

    }
}
