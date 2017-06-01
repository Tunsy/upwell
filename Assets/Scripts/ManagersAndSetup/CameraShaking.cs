using UnityEngine;
using System.Collections;

public class CameraShaking : MonoBehaviour {
    private Camera cam; // set this via inspector
    public float shakeTime;
    [HideInInspector]
    public float shakeAmount;
    public Vector3 originalPosition;
    private float decreaseFactor;
    private bool isShaking;

    void Start()
    {
        cam = Camera.main;
        decreaseFactor = 1;
    }

    public void Shake(float shakeAmount, float shakeTime)
    {
        StartCoroutine(ShakeCamera(shakeAmount, shakeTime));
    }

    public IEnumerator ShakeCamera(float shakeAmount, float shakeTime)
    {
        originalPosition = transform.position;
        isShaking = true;
        while(shakeTime >= 0)
        {
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x + Random.insideUnitCircle.x * shakeAmount,
                                    cam.transform.localPosition.y + Random.insideUnitCircle.y * shakeAmount,
                                    cam.transform.localPosition.z);
            shakeTime -= Time.deltaTime * decreaseFactor;
            yield return null;
        }
        transform.position = originalPosition;
        isShaking = false;
    }
}
