using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


namespace DesignPatterns.ObjectPool
{
    public class Turrent2 : MonoBehaviour
    {
        [SerializeField]
        private Bullet2 bulletPrefab;
        [SerializeField]
        private float bulletVelocity;
        [SerializeField]
        private Transform bulletSpawnPosition;
        [SerializeField]
        private float shootCooldown;

        private IObjectPool<Bullet2> objectPool;

        [SerializeField]
        private bool collectionCheck = true;

        [SerializeField]
        private int defaultCapacity = 20;
        [SerializeField]
        private int maxSize = 100;

        private float currentTime = 0f;

        void Awake()
        {
            objectPool = new ObjectPool<Bullet2>(CreateBullet, GetFromPool, ReleaseFromPool, DestroyPooledObject, 
                collectionCheck, defaultCapacity, maxSize);
        }

        private Bullet2 CreateBullet()
        {
            Bullet2 bullet = Instantiate(bulletPrefab, transform, true);
            bullet.ObjectPool = objectPool;
            return bullet;
        }

        private void GetFromPool(Bullet2 pooledObject)
        {
            pooledObject.gameObject.SetActive(true);
        }

        private void ReleaseFromPool(Bullet2 pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
        }

        private void DestroyPooledObject(Bullet2 pooledObject)
        {
            Destroy(pooledObject.gameObject);
        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButton(0) && currentTime >= shootCooldown && objectPool != null)
            {
                Bullet2 bullet = objectPool.Get();

                if (bullet == null)
                    return;

                bullet.transform.SetPositionAndRotation(bulletSpawnPosition.position, bulletSpawnPosition.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * bulletVelocity);

                bullet.Deactivate();

                currentTime = 0f;
            }
            currentTime += Time.fixedDeltaTime;
        }
    }
}