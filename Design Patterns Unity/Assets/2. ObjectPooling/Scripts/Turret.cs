using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.ObjectPool
{
    public class Turret : MonoBehaviour
    {
        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private float bulletVelocity;
        [SerializeField]
        private Transform bulletSpawnPosition;
        [SerializeField]
        private float shootCooldown;
        [SerializeField]
        private ObjectPool objectPool;

        private float currentTime = 0f;

        private void FixedUpdate()
        {
            if (Input.GetMouseButton(0) && currentTime >= shootCooldown && objectPool != null)
            {
                GameObject bulletGO = objectPool.GetPooledObject().gameObject;

                if (bulletGO == null)
                    return;

                bulletGO.transform.SetPositionAndRotation(bulletSpawnPosition.position, bulletSpawnPosition.rotation);
                bulletGO.GetComponent<Rigidbody2D>().AddForce(bulletGO.transform.right *  bulletVelocity);

                //  bullet will be deactivated after some time
                var bullet = bulletGO.GetComponent<Bullet>();
                bullet.Deactivate();

                currentTime = 0f;
            }
            currentTime += Time.fixedDeltaTime;
        }
    }
}