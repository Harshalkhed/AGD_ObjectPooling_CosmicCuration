using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    

    public class BulletPool
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullet> pooledBullets = new List<PooledBullet>();
        public BulletPool(BulletView bulletPrefab , BulletScriptableObject bulletScriptableObject)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletScriptableObject = bulletScriptableObject;
            
        }

        public BulletController GetBullet()
        {
            if (pooledBullets.Count > 0)
            {
                PooledBullet pooledBullet = pooledBullets.Find(item => !item.isUsed);
               
                if (pooledBullet != null)
                {
                    {
                        pooledBullet.isUsed = true;
                        return pooledBullet.Bullet;
                    }
                }
                
            }
            return CreateNewPooledBullet();
        }
        private BulletController CreateNewPooledBullet()
        {
            PooledBullet pooledBullet = new PooledBullet();
            pooledBullet.Bullet = new BulletController(bulletPrefab, bulletScriptableObject);
            pooledBullet.isUsed = true;
            pooledBullets.Add(pooledBullet);
            return pooledBullet.Bullet;
        }

        public void ReturnToBulletPool(BulletController returnedBullet)
        {
            PooledBullet pooledBullet=pooledBullets.Find(item=>item.Bullet.Equals(returnedBullet));
            pooledBullet.isUsed=false;
            
        }


        public class PooledBullet
        {
            public BulletController Bullet;
            public bool isUsed;
        }


    }

}
