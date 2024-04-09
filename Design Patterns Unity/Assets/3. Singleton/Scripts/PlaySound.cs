using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Singleton
{
    public class PlaySound : MonoBehaviour
    {
        [SerializeField]
        private AudioClip clip;

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AudioManager.Instance.PlaySoundEffect(clip);
            }
        }
    }
}