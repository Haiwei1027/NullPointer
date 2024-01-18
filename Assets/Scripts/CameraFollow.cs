using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance { get; private set; }

    private Vector3 previousTargetPosition;
    private Vector3 targetVelocity;
    public Transform Target { get ; private set; }

    public FollowModel followModel;

    private void Awake()
    {
        Instance = this;
    }

    public void SetTarget(Transform target)
    {
        this.Target = target;
    }

    protected virtual void FollowTarget()
    {
        Vector3 desiredPosition = Target.position;
        desiredPosition.y = transform.position.y;
        desiredPosition = Target.position + Vector3.up * followModel.height + (transform.position - desiredPosition).normalized * followModel.minDistance;
        if (followModel.velocityFactor != 0)
        {
            Vector3 filteredVelocity = targetVelocity;
            filteredVelocity.y = 0f;
            desiredPosition += followModel.velocityFactor * filteredVelocity;
        }
        Quaternion desiredRotation = Quaternion.LookRotation(Target.position + followModel.lookOffset + targetVelocity - transform.position, followModel.upAxis);

        transform.position = Vector3.Lerp(transform.position,desiredPosition,Time.deltaTime * followModel.linearSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.fixedDeltaTime * followModel.angularSpeed);
    }

    void FixedUpdate()
    {
        if (Target == null) { return; }
        targetVelocity = Target.position - previousTargetPosition;
        FollowTarget();
        previousTargetPosition = Target.position;
    }
}
