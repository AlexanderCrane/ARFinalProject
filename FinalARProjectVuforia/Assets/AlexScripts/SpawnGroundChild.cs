using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGroundChild : MonoBehaviour
{
    //Public variables (Can be referenced in the scene)
    public GameObject objToSpawn;

    public GameObject redSphere;

    public GameObject purpleSphere;

    public GameObject blueSphere;

    public GameObject groundPlane;

    //Private variables
    bool red;

    bool purple;

    bool blue;

    //Class methods:

    // Start is called before the first frame update
    void Start()
    {
        objToSpawn.SetActive(false);   
    }

    public void redClicked(){
        red = true;
    }
    
    public void purpleClicked(){
        purple = true;
    }

    public void blueClicked(){
        blue = true;
    }

    //This is called (along with one of the above methods) when one of the UI buttons is clicked. 
    //Depending on which button was clicked, it will instantiate a cube at the same location as the recognized image's child object,
    // and change its material to match its respective 'spawner'. These cubes are then attached to the ground plane, registering them
    // to the environment.
    public void SpawnObject(){
        GameObject newObj = objToSpawn;
        bool newObjChanged = false;
        if(red){
            //This final parameter to instantiate is optional, and signifies what object in the scene should be made the parent of the instantiated object.
            //Here, by making the ground plane the parent, the instantiated object becomes registered to the environment, and independant of image tracking.
            newObj = Instantiate(objToSpawn,redSphere.transform.position, Quaternion.identity, groundPlane.transform);
            MeshRenderer m = newObj.GetComponent<MeshRenderer>();
            m.material = redSphere.GetComponent<MeshRenderer>().material;
            red = false;
            newObjChanged = true;
        } else if(purple) {
            newObj = Instantiate(objToSpawn,purpleSphere.transform.position, Quaternion.identity, groundPlane.transform); 
            MeshRenderer m = newObj.GetComponent<MeshRenderer>();
            m.material = purpleSphere.GetComponent<MeshRenderer>().material;
            purple = false; 
            newObjChanged = true;
        } else if(blue) {
            newObj = Instantiate(objToSpawn,blueSphere.transform.position, Quaternion.identity, groundPlane.transform); 
            MeshRenderer m = newObj.GetComponent<MeshRenderer>();
            m.material = blueSphere.GetComponent<MeshRenderer>().material;
            blue = false;
            newObjChanged = true;
        }

        if(newObjChanged){
            newObj.SetActive(true);
        } else {
            newObj.SetActive(false);
        }
    }
}
