using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesignPatterns.Factory
{
    public class EntityFactoryB : Factory
    {
        [SerializeField]
        private EntityB entityPrefab;

        public override IEntity GetEntity(Vector3 position)
        {
            EntityB entity = Instantiate(entityPrefab, position, Quaternion.identity);

            // each entity has its own logic
            entity.Initialize();

            // unique behavior of this factory
            entity.gameObject.name = entity.EntityName;
            Debug.Log(Log(entity));

            return entity;
        }
    }
}