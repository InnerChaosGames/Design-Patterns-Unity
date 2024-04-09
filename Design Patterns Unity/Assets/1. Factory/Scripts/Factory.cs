using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    // base class for factories
    public abstract class Factory : MonoBehaviour
    {
        public abstract IEntity GetEntity(Vector3 position);

        // shared method with all factories
        public string Log(IEntity product)
        {
            return "Factory: created entity " + product.EntityName;
        }
    }
}
