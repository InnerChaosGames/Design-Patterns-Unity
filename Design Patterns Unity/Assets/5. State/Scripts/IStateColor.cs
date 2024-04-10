using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    public interface IStateColor 
    {
        public Color StateColor { get; set; }
    }
}