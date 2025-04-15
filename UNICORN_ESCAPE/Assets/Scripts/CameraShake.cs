using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.5f;
    [SerializeField] private float shakeMagnitudeX = 0.1f;
    [SerializeField] private float shakeMagnitudeY = 0.1f;
    [SerializeField] private float shakeSpeed = 20f;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void Shake()
    {
        StopAllCoroutines(); // Optional: stop previous shake
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        // Generate random noise seed
        float seedX = Random.value * 100f;
        float seedY = Random.value * 100f;

        while (elapsedTime < shakeDuration)
        {
            float time = Time.time * shakeSpeed;

            float offsetX = (Mathf.PerlinNoise(seedX, time) - 0.5f) * 2f * shakeMagnitudeX;
            float offsetY = (Mathf.PerlinNoise(seedY, time) - 0.5f) * 2f * shakeMagnitudeY;

            transform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0f);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}

