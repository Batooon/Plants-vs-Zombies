using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField]private Transform _attackPoint;

    public void Init()
    {
        InvokeRepeating(nameof(Attack), 0f, .3f);
    }
    
    private void Attack()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _attackPoint.position, Quaternion.identity);
    }
}