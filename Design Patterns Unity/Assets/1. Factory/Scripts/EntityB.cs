using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class EntityB : MonoBehaviour, IEntity
    {
        [SerializeField]
        private string entityName = "EntityA";
        public string EntityName { get => entityName; set => entityName = value; }

        private AudioSource audio;

        public void Initialize()
        {
            // init logic here
            audio = GetComponent<AudioSource>();
            audio?.Stop();
            audio?.Play();
        }
    }
}