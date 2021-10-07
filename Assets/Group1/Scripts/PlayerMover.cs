using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private const int SpeedMultiplier = 2;
    private const float BoostTime = 2;
    private float _currentBoostTime;
    public bool _isBoosted;

    public event UnityAction<GameObject> EnemyKilled;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Input.GetAxis("Horizontal") * new Vector3(_speed * Time.deltaTime, 0, 0);
        transform.position += Input.GetAxis("Vertical") * new Vector3(0, _speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>())
        {
            EnemyKilled?.Invoke(other.gameObject);
            GetBoostSpeed();
        }
    }

    private void GetBoostSpeed()
    {
        if (!_isBoosted)
        {
            _speed *= SpeedMultiplier;
            _isBoosted = true;
        }
            
        _currentBoostTime = BoostTime;
        StartCoroutine(StartBoostTimer());
            
        if (_currentBoostTime == 0)
        {
            _isBoosted = false;
            _speed /= SpeedMultiplier;
        }
    }

    private IEnumerator StartBoostTimer()
    {
        const int Delay = 1;
        
        while (_currentBoostTime > 0)
        {
            yield return new WaitForSeconds(Delay);
            _currentBoostTime--;
        }
    }
}
