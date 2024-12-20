using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private Light platLight;
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                platLight = other.gameObject.GetComponentInChildren<Light>();
                Debug.Log("Collided with: " + other.gameObject.name);
                platLight.color = Color.green;
                break;
            default:
                Debug.Log("BOOM!");
                break;
        }
    }
}
