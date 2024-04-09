using DesignPatterns.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField]
    private Subject subjectToObserve;

    // method to handle event (the function signature must match the subject's event)
    private void OnThingHappened()
    {
        // logic goes here
    }

    private void Awake()
    {
        // subscribe to the subject's event
        subjectToObserve.SomethingHappend += OnThingHappened;
    }

    private void OnDestroy()
    {
        // unsubscrive if the object is destroyed
        subjectToObserve.SomethingHappend -= OnThingHappened;
    }
}
