using UnityEngine;

public class AttackView : MonoBehaviour
{
    public Vector3 Direction { get; private set; }
    public float Speed { get; private set; }
    public void ShootDirection(Vector3 direction, float speed)
    {
        Direction = direction;
        Speed = speed;
       
    }

    void Update()
    {
        transform.position += Direction * (Time.deltaTime * Speed);
    }
  
}
