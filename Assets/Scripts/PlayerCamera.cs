using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed = 10;

    private void LateUpdate()
    {
        var nextPosition = target.position + offset;
        
        transform.position = Vector3.Lerp(transform.position, nextPosition, Time.deltaTime * speed);
    }
}
