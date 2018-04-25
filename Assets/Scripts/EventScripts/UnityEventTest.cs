using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour {

    public UnityEvent OnObjectStart; // Unity Event Object, public so it shows in the Inspector

	// Use this for initialization
	void Start () {

        OnObjectStart.Invoke(); // Calls the UnityEvent in this Objects start function

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
