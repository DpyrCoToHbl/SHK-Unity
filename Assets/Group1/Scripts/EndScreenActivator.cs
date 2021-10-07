using UnityEngine;

public class EndScreenActivator : MonoBehaviour
{
    [SerializeField] private EnemyHolder _enemyHolder;
    [SerializeField] private GameObject _endScreen;

    private void OnEnable()
    {
        _enemyHolder.AllEnemyKilled += OnAllEnemyKilled;
    }

    private void OnDisable()
    {
        _enemyHolder.AllEnemyKilled -= OnAllEnemyKilled;
    }

    private void OnAllEnemyKilled()
    {
        _endScreen.SetActive(true);
    }
}
