using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public interface IEntity
    {
        public string EntityName { get; set; }
        public void Initialize();
    }
}