using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTest : MonoBehaviour {

    public int timeBetweenSpawn; // How long between each item being set active
    public GameObject prefab; // Object prefab 
    private Transform tf; // Transform variable for this object

    private void Awake()
    {
        tf = GetComponent<Transform>(); // Sets transform variable
    }

    // Use this for initialization
    void Start () {

        StartCoroutine(CreateObject()); // Runs the Coroutine CreateObject
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // This "Spawns" objects from the object pool at a random position around the cube in the scene
    IEnumerator CreateObject()
    {
        // Never ending loop
        while(true)
        {
            // Sets a Vector3 to a random value within 5 units of this object
            Vector3 newpos = new Vector3(tf.position.x + Random.Range(tf.position.x - 5, tf.position.x + 5), tf.position.y + Random.Range(tf.position.y - 5, tf.position.y + 5), tf.position.z + Random.Range(tf.position.z - 5, tf.position.z + 5));

            // Calls the ObjectPools GetObject function passing in the prefab, newPosition and uses this objects current rotation
            ObjectPool.instance.GetObject(prefab, newpos, tf.rotation);

            yield return new WaitForSeconds(timeBetweenSpawn); // Tells the corouting to wait until timeBetweenSpawn seconds have passed.
        }
    }
}
