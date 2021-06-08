using System.Collections;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    [SerializeField] private float Duration = 0;
    [SerializeField] private float Intensity = 0.5f;

    Vector3 originalPosition;

    public void Shake(float newDuration)
    {
        originalPosition = this.transform.localPosition;
        Duration = newDuration;
        StartCoroutine(UpdatePosition());
    }

    IEnumerator UpdatePosition()
    {
        while (Duration > 0f)
        {
            this.transform.localPosition = originalPosition + Random.insideUnitSphere * Intensity;
            Duration -= Time.deltaTime;
            yield return null;
        }
        Duration = 0f;
        this.transform.localPosition = originalPosition;
    }
}
