using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    /// <summary>
    /// Returns y-position of the highest child object
    /// </summary>
    public float topY
    {
        get
        {
            float maxY = this.transform.position.y;
            foreach (Transform child in this.transform)
            {
                maxY = Mathf.Max(maxY, child.transform.position.y);
            }

            return maxY;
        }
    }
}
