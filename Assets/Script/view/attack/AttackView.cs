using UnityEngine;

public class AttackView : MonoBehaviour
{
    private float speedAttack = 10f;
    public Vector3 Direction { get; private set; }
    public float Speed { get; private set; }

    public int DamageAffected { get; private set; }
    public float SpeedAffected { get; private set; }
    public void ShootDirection(float speed, Vector3 direction,int damageAffected, float speedAffected)
    {
        Direction = direction;
        DamageAffected = damageAffected;
        SpeedAffected = speedAffected;
        speedAttack += speed;
    }

    void Update()
    {
        transform.position += Direction * (Time.deltaTime * speedAttack);
    }
  
}
