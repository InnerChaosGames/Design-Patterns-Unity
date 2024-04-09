using DesignPatterns.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class EntityFactoryA : Factory
    {
        [SerializeField]
        private EntityA entityPrefab;

        public override IEntity GetEntity(Vector3 position)
        {
            EntityA entity = Instantiate(entityPrefab, position, Quaternion.identity);
            
            // each entity has its own logic
            entity.Initialize();

            return entity;
        }
    }
}