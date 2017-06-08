using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public PlayerController player;
    public Vector2 focusAreaSize;
    public float verticalOffset;
    public float verticalSmoothTime;
    public bool showFocusArea = false;
    public CameraShaking shake;

    Collider2D playerCollider;
    FocusArea focusArea;

    float smoothVelocityY;

    public void FixedUpdate()
    {
        if (GameManager.instance.isAlive() && shake.shakeTime <= 0)
        {
            if (player.GetComponent<PlayerController>().CheckInvert())
            {
                //transform.eulerAngles = new Vector3(10, yRotation, 0);
                this.transform.rotation = new Quaternion(0, 0, 180, 0);
            }
            else
            {
                this.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }

    struct FocusArea
    {
        public Vector2 center;
        float left, right, top, bottom;
        
        public FocusArea (Bounds targetBounds, Vector2 size){
            left = targetBounds.center.x - size.x / 2;
            right = targetBounds.center.x + size.x / 2;
            bottom = targetBounds.min.y;
            top = targetBounds.min.y + size.y;

            center = new Vector2((left + right) / 2, (top + bottom)/2);
        }

        public void Update(Bounds targetBounds)
        {
            float shiftX = 0;
            float shiftY = 0;
            if (targetBounds.min.x < left)
            {
                shiftX = targetBounds.min.x - left;
                
            }
            else if (targetBounds.max.x > right)
            {
                shiftX = targetBounds.max.x - right;
            }
            left += shiftX;
            right += shiftX;

            if (targetBounds.min.y < bottom)
            {
                shiftY = targetBounds.min.y - bottom;

            }
            else if (targetBounds.max.y > top)
            {
                shiftY = targetBounds.max.y - top;
            }
            top += shiftY;
            bottom += shiftY;

            center += new Vector2(shiftX, shiftY);
        }
    }

	void Start () {
        player = FindObjectOfType<PlayerController>();
        playerCollider = player.GetComponent<Collider2D>();
        focusArea = new FocusArea(playerCollider.bounds, focusAreaSize);
        shake = GetComponent<CameraShaking>();
    }

    void LateUpdate()
    {
        if (GameManager.instance.isAlive())
        {
            if (playerCollider != null)
            {
                focusArea.Update(playerCollider.bounds);

                float focusPositionY = focusArea.center.y + verticalOffset;
                focusPositionY = Mathf.SmoothDamp(this.transform.position.y, focusPositionY, ref smoothVelocityY, verticalSmoothTime);

                    this.transform.position = new Vector3(transform.position.x, focusPositionY, -10);
            }
        }
    }
	
	void OnDrawGizmos()
    {
        if (showFocusArea)
        {
            Gizmos.color = new Color(1, 0, 0, .5f);
            Gizmos.DrawCube(focusArea.center, focusAreaSize);
        }
    }
}
