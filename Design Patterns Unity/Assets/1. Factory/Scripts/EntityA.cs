using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class EntityA : MonoBehaviour, IEntity
    {
        [SerializeField]
        private string entityName = "EntityA";
        public string EntityName { get => entityName; set => entityName = value; }

        private ParticleSystem ps;

        public void Initialize()
        {
            // adding unique logic to this entity
            gameObject.name = entityName;
            ps = GetComponentInChildren<ParticleSystem>();
            ps?.Stop();
            ps?.Play();
        }
    }
}