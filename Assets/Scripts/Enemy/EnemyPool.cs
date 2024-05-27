using CosmicCuration.Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CosmicCuration.Enemy.EnemyPool;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyView enemyView;
        private EnemyScriptableObject enemyScriptableObject;
        private EnemyData enemyData;
        private List<PooledEnemy> pooledEnemies=new List<PooledEnemy>();

        public EnemyPool(EnemyView enemyView,EnemyScriptableObject enemyScriptableObject)
        { 
         this.enemyView = enemyView;
         this.enemyScriptableObject = enemyScriptableObject;
            
        }

        public EnemyController GetEnemy()
        {
            if(pooledEnemies.Count > 0)
            {
                PooledEnemy pooledEnemy=pooledEnemies.Find(item=>item.isUsed);

                if (pooledEnemy != null) 
                    {
                        pooledEnemy.isUsed=true;
                        return pooledEnemy.enemy;
                    }
             }
                return CreateNewPoolEnemy();
        }
        private EnemyController CreateNewPoolEnemy()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.enemy = new EnemyController(enemyView, enemyScriptableObject.enemyData);
            pooledEnemy.isUsed = true;
            pooledEnemies.Add(pooledEnemy);
            return pooledEnemy.enemy;
        }

        public void ReturnToEnemyPool(EnemyController returnrdenemy)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(item => item.enemy.Equals(returnrdenemy));
            pooledEnemy.isUsed=false;
        }
        public class PooledEnemy
        {
            public EnemyController enemy;
            public bool isUsed;
        }


    }
}

