using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private const int Radius = 4;
    private const float Speed = 2;
    private Vector3 _target;
    private float _step;

    private void Start()
    {
        _step = Speed * Time.deltaTime;
        GetTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _step);

        if (transform.position == _target)
            GetTargetPosition();
    }

    private void GetTargetPosition()
    {
        _target = Random.insideUnitCircle * Radius;
    }
}
