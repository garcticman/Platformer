using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private Animator animator;
    [SerializeField] private float rotationSpeed = 1;

    private Vector3 _nextPositionTmp;
    private Vector3 _direction;
    
    private static readonly int Run = Animator.StringToHash("run");

    private void Update()
    {
        Movement();
        DoRotation();
        RunAnimation();
    }

    private void DoRotation()
    {
        var rotation = transform.rotation;

        var angle = Vector3.SignedAngle(transform.forward, _direction, Vector3.up);
        rotation *= Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    private void Movement()
    {
        _nextPositionTmp = Vector3.right * (Input.GetAxis("Horizontal") * speed) +
                           Vector3.forward * (Input.GetAxis("Vertical") * speed);

        transform.position += _nextPositionTmp * Time.deltaTime;

        if (_nextPositionTmp != Vector3.zero)
        {
            _direction = _nextPositionTmp.normalized;
        }
    }

    private void RunAnimation()
    {
        animator.SetBool(Run, _nextPositionTmp != Vector3.zero);
    }
}
