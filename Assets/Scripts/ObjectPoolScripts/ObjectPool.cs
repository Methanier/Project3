using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public static ObjectPool instance; // Creates a singleton of this object
    public List<GameObject> pool; // List to hold objects in the pool
    public int numberOfObjects; // How many objects to create at startup
    public GameObject prefabObject; // Prefab of the objects to create, Note this could also be a list, and you could create variables for how many of each type to create.

    private void Awake()
    {
        // Ensures that only one ObejctPool is in the scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {

        //Initializes the ObjectPool
        InitPool();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Function for Intializing the pool
    public void InitPool()
    {
        pool = new List<GameObject>(); // Sets pool to a new empty List of type GameObject

        // Loops through the number of times numberOfObjects is set for
        for(int i = 0; i < numberOfObjects; i++)
        {
            GameObject temp = Instantiate(prefabObject); // Instantiates the game object
            temp.SetActive(false); // Sets the object to inactive
            pool.Add(temp); // Adds the object to the pool
        }
    }

    // Function for returning a GameObject from the pool
    public GameObject GetObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        // Loops through the object pool
        foreach(GameObject obj in pool)
        {
            // If the current object is not active in the scene
            if(!obj.activeInHierarchy)
            {
                obj.name = prefab.name; // Sets the object name to the name of the passed in prefab
                obj.transform.position = position; // Sets the objects position to the passed in position
                obj.transform.rotation = rotation; // Sets the objects rotation to the passed in rotation

                obj.SetActive(true); // Sets the object as active in the scene

                return obj; // Returns the object
            }
        }

        // This section is if all objects in the pool are currently active

        GameObject newObject = Instantiate(prefab); // Instantiates a new object
        newObject.name = prefab.name; // Sets the object name to the name of the passed in prefab
        newObject.transform.position = position; // Sets the objects position to the passed in position
        newObject.transform.rotation = rotation; // Sets the objects rotation to the passed in rotation

        newObject.SetActive(true); // Ensures Object is active in the scene

        pool.Add(newObject); // Adds the Object to the pool

        return newObject; // Returns the new object
    }
}
