using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemObserver : MonoBehaviour
{
    [SerializeField]
    private ButtonSubject subject;

    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        subject.Clicked += ButtonPressed;
    }

    private void ButtonPressed()
    {
        if (particleSystem != null)
        {
            particleSystem.Stop();
            particleSystem.Play();
        }
    }


    private void OnDestroy()
    {
        subject.Clicked -= ButtonPressed;
    }
}
