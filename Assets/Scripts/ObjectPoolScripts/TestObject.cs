using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour {

    public int lifeSpan; // Variable to set how long object is active for
    private float timeToDie; // Variable for when to set the object inactive

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // If the current time is greater than timeTodie
        if (Time.time > timeToDie)
            OnDie(); // Calls OnDie Function	
	}


    void OnDie()
    {
        gameObject.SetActive(false);  // Sets Object inactive
    }

    // This function runs any time the object is set active in the Hierarchy
    private void OnEnable()
    {
        // Sets the timeToDie variable
        timeToDie = Time.time + lifeSpan;
    }
}
