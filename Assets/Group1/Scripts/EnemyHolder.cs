using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHolder : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private PlayerMover _playerMover;

    private int _enemyCount;

    public event UnityAction AllEnemyKilled;

    private void Start()
    {
        _enemyCount = _enemies.Count;
    }

    private void OnEnable()
    {
        _playerMover.EnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        _playerMover.EnemyKilled -= OnEnemyKilled;
    }

    private void OnEnemyKilled(GameObject enemy)
    {
        Destroy(enemy);
        _enemyCount--;
        
        if (_enemyCount == 0)
        {
            AllEnemyKilled?.Invoke();
        }
    }
}
