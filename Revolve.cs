using UnityEngine;

public class Revolve : MonoBehaviour
{
    public Transform parentObject;
    public float distanceFromParent = 3.0f;
    public float revolutionSpeed = 5.0f; 
    public float rotationSpeed = 30.0f; 

    private void Update()
    {
        Matrix4x4 transMat = Matrix4x4.Translate(new Vector3(distanceFromParent, 0, 0));
        Matrix4x4 rotMat = Matrix4x4.Rotate(Quaternion.Euler(0, revolutionSpeed * Time.deltaTime, 0));
        Vector3 newPos = rotMat.MultiplyPoint3x4(transMat.MultiplyPoint3x4(transform.position - parentObject.position)) + parentObject.position;
        transform.position = newPos;

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (parentObject)
            parentObject.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
