using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public static ObstacleObjectPool Instance;

    public GameObject obstacleBarrelPrefab;
    public GameObject obstacleBarrierPrefab;
    public GameObject obstacleStoneWallPrefab;
    public int poolSize = 10;

    private List<GameObject> obstacleBarrelPool;
    private List<GameObject> obstacleBarrierPool;
    private List<GameObject> obstacleStoneWallPool;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        obstacleBarrelPool = new List<GameObject>();
        obstacleBarrierPool = new List<GameObject>();
        obstacleStoneWallPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject barrel = Instantiate(obstacleBarrelPrefab);
            barrel.SetActive(false);
            obstacleBarrelPool.Add(barrel);

            GameObject barrier = Instantiate(obstacleBarrierPrefab);
            barrier.SetActive(false);
            obstacleBarrierPool.Add(barrier);

            GameObject stoneWall = Instantiate(obstacleStoneWallPrefab);
            stoneWall.SetActive(false);
            obstacleStoneWallPool.Add(stoneWall);
        }
    }

    public GameObject Acquire(int obstacleType)
    {
        List<GameObject> targetPool = null;

        if (obstacleType == 0) targetPool = obstacleBarrelPool;
        else if (obstacleType == 1) targetPool = obstacleBarrierPool;
        else if (obstacleType == 2) targetPool = obstacleStoneWallPool;

        if (targetPool != null)
        {
            for (int i = 0; i < targetPool.Count; i++)
            {
                if (!targetPool[i].activeInHierarchy)
                {
                    targetPool[i].SetActive(true);
                    return targetPool[i];
                }
            }
        }

        return null;
    }

    public void Release(GameObject obstacle, int obstacleType)
    {
        if (obstacle != null)
        {
            obstacle.SetActive(false);
        }
    }
}
