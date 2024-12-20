using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Landing : MonoBehaviour
{
    Light platLight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platLight = GetComponentInChildren<Light>();
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided with: " + other.gameObject.name);
        platLight.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
