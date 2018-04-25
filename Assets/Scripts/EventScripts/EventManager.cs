using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Struct for creating Event types
public struct Event
{
    public string eventID;
    public int eventData;

    public Event(string id, int data)
    {
        eventID = id;
        eventData = data;
    }
}

//Event Manager Class
public class EventManager {

    public delegate void CallbackMethod(Event inEvent); // Creates Delegate to hold event functions

    public static Queue<Event> eventQueue = new Queue<Event>(); // Creats Queue to hold multiple events

    private static Dictionary<Event, CallbackMethod> listeners = new Dictionary<Event, CallbackMethod>(); // Creates Dictionary to hold events, and their listners

    // Function adds listeners to an Event
    public static void SubscribeListener(Event inEvent, CallbackMethod listener)
    {
        // If the event is not in the dictionary
        if(!listeners.ContainsKey(inEvent))
        {
            listeners.Add(inEvent, listener); //Adds the event with the listener to the dictionary
        } 
        // If the event is in the Dicitionary
        else
        {
            listeners[inEvent] += listener; //Adds the listener to the event
        }
    }

    //Removes listeners from events
    public static void UnSubscribeListener(Event inEvent, CallbackMethod listener)
    {
        //If the event is in the dictionary
        if(listeners.ContainsKey(inEvent))
        {
            listeners[inEvent] -= listener; //Removes the listener from the event

            //If the event has no listeners
            if (listeners[inEvent] == null)
            {
                listeners.Remove(inEvent); //removes the event from the dicitonary
            }
        }
    }

    //Adds events to the queue
    public static void QueueEvent(Event inEvent)
    {
        eventQueue.Enqueue(inEvent);
    }

    // Calls the next event in the queue
    public static void NextEvent()
    {
        if(eventQueue.Count > 0)
        {
            TriggerEvent(eventQueue.Dequeue());
        }
    }

    // Runs an event
    public static void TriggerEvent(Event inEvent)
    {
        if(listeners.ContainsKey(inEvent))
        {
            listeners[inEvent](inEvent);
        }
    }

}
