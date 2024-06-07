using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomInstance : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 targetScale;
    private Vector3 originalPosition;

    void Awake()
    {
        originalScale = transform.localScale;
        originalPosition = transform.position;
        StartCoroutine(AnimationCoroutine());
    }

    private IEnumerator AnimationCoroutine()
    {
       // Set a quick scale-up duration
        float scaleUpDuration = 0.2f; // Short duration for a quick scale-up effect
        float elapsedTime = 0f;

        // Set the target scale for the explosion effect
        Vector3 explosionScale = originalScale * 3f; // Adjust the multiplier for desired explosion size

        while (elapsedTime < scaleUpDuration)
        {
            // Scale up quickly
            transform.localScale = Vector3.Lerp(originalScale, explosionScale, (elapsedTime / scaleUpDuration));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Optionally, add a slight delay before destroying if needed
        yield return new WaitForSeconds(0.1f); // Adjust delay as needed

        Destroy(gameObject); // Destroy the object after the animation
    }
}