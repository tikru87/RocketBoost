using UnityEngine;

public class RocketFeatures : MonoBehaviour
{
    Flying flying;
    float gasLevel = 100f;
    public bool hasGas = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flying = GetComponent<Flying>();
    }

    // Update is called once per frame
    void Update()
    {
        processGas();
    }

    void processGas()
    {
        if (gasLevel <= 0)
        {
            hasGas = false;
        }

        if (flying.isThrusting && hasGas)
        {
            Debug.Log(gasLevel);
            gasLevel -= 0.1f;
        }
    }
}
