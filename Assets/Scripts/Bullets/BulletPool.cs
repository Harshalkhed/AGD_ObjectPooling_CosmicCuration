using System.Collections.Generic;
using CosmicCuration.Utilities;

namespace CosmicCuration.Bullets
{
    public class BulletPool: GenericObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletSO;
       // private List<PooledBullet> pooledBullets = new List<PooledBullet>();

        public BulletPool(BulletView bulletPrefab, BulletScriptableObject bulletSO)
        {
            this.bulletPrefab = bulletPrefab;
            this.bulletSO = bulletSO;
        }
        protected override BulletController CreateItem() => new BulletController(bulletPrefab, bulletSO);
        public BulletController GetBullet() => GetItem();
        
            //if (pooledBullets.Count > 0)
            //{
            //    PooledBullet item = pooledBullets.Find(item => !item.isUsed);
            //    if (item != null)
            //    {
            //        item.isUsed = true;
            //        return item.Bullet;
            //    }
            //}
            //return CreateNewPooledBullet();
        //}

        //private BulletController CreateNewPooledBullet()
        //{
        //    PooledBullet newBullet = new PooledBullet();
        //    newBullet.Bullet = CreateBullet();
        //    newBullet.isUsed = true;
        //    pooledBullets.Add(newBullet);
        //    return newBullet.Bullet;
        //}

        //private BulletController CreateBullet() => new BulletController(bulletPrefab, bulletSO);

        //public void ReturnBullet(BulletController bullet)
        //{
        //    PooledBullet pooledBullet = pooledBullets.Find(i => i.Bullet.Equals(bullet));
        //    pooledBullet.isUsed = false;
        //}

        //public class PooledBullet
        //{
        //    public BulletController Bullet;
        //    public bool isUsed;
        //}
    }
}