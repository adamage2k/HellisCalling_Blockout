using UnityEngine;

public class PushObjects : MonoBehaviour
{
    [SerializeField] private ThirdPersonController _cC;
    private float _pushPower = 4;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag != "Decoration")
            return;

        Debug.Log("XD");
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
            return;
        if (hit.moveDirection.y < -0.3f)
            return;
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        //body.angularVelocity = pushDir * _pushPower;
        Vector3 collisionPoint = hit.point;
        body.AddForceAtPosition(pushDir * _pushPower, collisionPoint, ForceMode.Impulse);
    }
}
