using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    Flying flying;
    private Light platLight;
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                flying = GetComponent<Flying>();
                platLight = other.gameObject.GetComponentInChildren<Light>();
                Debug.Log("Collided with: " + other.gameObject.name);
                flying.DisableControls();
                platLight.color = Color.green;
                SceneManager.LoadScene(0);
                break;
            default:
                Debug.Log("BOOM!");
                break;
        }
    }
}
