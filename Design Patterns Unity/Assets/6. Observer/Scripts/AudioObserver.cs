using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioObserver : MonoBehaviour
{
    [SerializeField]
    ButtonSubject subject;
    [SerializeField]
    private float delay = 0f;

    private AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();

        if (subject != null )
        {
            subject.Clicked += OnButtonClick;
        }
    }

    private void OnButtonClick()
    {
        StartCoroutine(PlayWithDelay());
    }

    IEnumerator PlayWithDelay()
    {
        yield return new WaitForSeconds(delay);
        source.Stop();
        source.Play();
    }

    private void OnDestroy()
    {
        subject.Clicked -= OnButtonClick;
    }
}
