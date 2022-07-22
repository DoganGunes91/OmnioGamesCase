using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInPool : MonoBehaviour
{
    [SerializeField] private Transform _playerPoint;

    [SerializeField] private ObjectPooling _objectPool;

    [SerializeField] private int _chunkPoolSize;

    Queue<GameObject> Friends = new Queue<GameObject>();

    Queue<GameObject> Enemies = new Queue<GameObject>();

    Queue<GameObject> Chunks = new Queue<GameObject>();

    Queue<GameObject> ChunkEnd = new Queue<GameObject>();

    void Start()
    {
        InvokeRepeating(nameof(Friend), 0f, 2f);
        InvokeRepeating(nameof(Enemy), 0f, 1.2f);
        InvokeRepeating(nameof(FriendHide), 10, 5);
        InvokeRepeating(nameof(EnemyHide), 5.5f, 1.5f);        

        for (int i = 0; i < _chunkPoolSize; i++)
        {
            GameObject chunk = _objectPool.GetPoolObject(2);
            chunk.transform.transform.position = new Vector3(0,0,10 * i);
            Chunks.Enqueue(chunk);
        }

        GameObject chunkEnd = _objectPool.GetPoolObject(3);
        chunkEnd.transform.transform.position = new Vector3(0,0,10 * _chunkPoolSize);
        ChunkEnd.Enqueue(chunkEnd);        
    }    
    void Friend()
    {        
        GameObject friend = _objectPool.GetPoolObject(0);
        friend.transform.transform.position = new Vector3(1, 0, _playerPoint.position.z + 20);
        Friends.Enqueue(friend);
    }
    void Enemy()
    {        
        GameObject enemy = _objectPool.GetPoolObject(1);
        enemy.transform.transform.position = new Vector3(-1, 0, _playerPoint.position.z + 80);
        Enemies.Enqueue(enemy);
    }
    void FriendHide()
    {
        if (Friends.Count == 0) return;
        GameObject friend = Friends.Dequeue();
        _objectPool.SetPoolObject(friend, 0);
    }
    void EnemyHide()
    {
        if (Enemies.Count == 0) return;
        GameObject enemy = Enemies.Dequeue();
        _objectPool.SetPoolObject(enemy, 1);
    }    
}
