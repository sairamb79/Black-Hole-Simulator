using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Singularity : MonoBehaviour
{
    [SerializeField] public float GRAVITY_PULL = 100f;
    public static float m_GravityRadius = 0.5f;

    void Awake()
    {
        m_GravityRadius = GetComponent<SphereCollider>().radius;

        if (GetComponent<SphereCollider>())
        {
            GetComponent<SphereCollider>().isTrigger = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        Rigidbody otherRigidbody = other.attachedRigidbody;

        if (otherRigidbody && other.GetComponent<SingularityPullable>())
        {
            if (!otherRigidbody.isKinematic)
            {
                float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
                otherRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * otherRigidbody.mass * GRAVITY_PULL * Time.smoothDeltaTime);
            }
        }
    }
}
