using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ObjectPool
{
    public class GunControl : MonoBehaviour
    {
        [SerializeField]
        private Transform gunPivot;

        private Camera camera;

        // Start is called before the first frame update
        void Awake()
        {
            camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 dir = camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gunPivot.rotation = rotation;
        }
    }
}