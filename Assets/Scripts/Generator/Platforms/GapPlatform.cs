using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GapPlatform : MonoBehaviour, PlatformInterface {
    public float minGapWidth, maxGapWidth;
    public GameObject leftPlatform, rightPlatform;
    float gapWidth;

    public void Initialize()
    {
        gapWidth = Random.Range(minGapWidth, maxGapWidth);
        Vector3 center = this.transform.position;
        leftPlatform.transform.position = center - new Vector3(leftPlatform.transform.localScale.x + gapWidth / 2, 0f, 0f);
        rightPlatform.transform.position = center + new Vector3(rightPlatform.transform.localScale.x + gapWidth / 2, 0f, 0f);

        float horizontalNoise = Random.Range(-5f, 5f);
        this.transform.Translate(new Vector3(horizontalNoise, 0, 0));
    }
}
