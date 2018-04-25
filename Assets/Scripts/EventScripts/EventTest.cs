using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour {
    
    Event ON_TEST; // Test event
    Event ON_ACTIVATE;

	// Use this for initialization
	void Start () {

        //Sets ON_TEST variables
        ON_TEST.eventID = "On_Test";
        ON_TEST.eventData = 1;

        ON_ACTIVATE.eventID = "ON_ACTIVATE";
        ON_ACTIVATE.eventData = 0;

        RunTest();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RunObjectPoolTest()
    {
        
    }

    public void RunTest()
    {
        // Testing Basic Trigger
        EventManager.CallbackMethod eventDelagate; // creates a CallbackMethod delegate variable

        eventDelagate = OnEvent; // Sets eventDelagate to the OnEvent function

        EventManager.SubscribeListener(ON_TEST, eventDelagate); // Adds eventDelegate as a listener to the ON_TEST event

        EventManager.TriggerEvent(ON_TEST); // Calls the ON_TEST event

        EventManager.UnSubscribeListener(ON_TEST, eventDelagate); // Removes eventDelegate as a listener of ON_TEST

        EventManager.TriggerEvent(ON_TEST); // Attempts to call the ON_TEST event again, will do nothing as the even has been removed as it had 0 listeners

        // Testing Event Queue

        //Creates multiple events
        Event eventOne = new Event();
        eventOne.eventID = "EventOne";
        eventOne.eventData = 1;

        Event eventTwo = new Event();
        eventTwo.eventID = "Player Died";
        eventTwo.eventData = 100;

        Event eventThree = new Event();
        eventThree.eventID = "Enemy Died";
        eventThree.eventData = 999;

        EventManager.SubscribeListener(eventOne, eventDelagate); // Adds eventDelegate as a listener to the eventOne event 
        EventManager.SubscribeListener(eventTwo, eventDelagate); // Adds eventDelegate as a listener to the eventTwo event

        // Adds the events to the Queue
        EventManager.QueueEvent(eventOne);
        EventManager.QueueEvent(eventTwo);
        EventManager.QueueEvent(eventThree);

        // Calls the events from the queue
        EventManager.NextEvent();
        EventManager.NextEvent();

        // This will call eventThree, you'll notice nothing happens. This is due to the fact there are no listeners subscribed to eventThree
        EventManager.NextEvent();

        // Attempts to call event from Queue to show it will do nothing if the Queue is empty
        EventManager.NextEvent();

    }

    //On Event function used to show events running
    public void OnEvent(Event inEvent)
    {
        Debug.Log("Event " + inEvent.eventID + " ran. EventData = " + inEvent.eventData);
    }

    public void UnityEventFunction(string test)
    {
        Debug.Log("This ran using Unity Event, the test value = " + test);
    }
}
