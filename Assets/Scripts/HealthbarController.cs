using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarController : MonoBehaviour {
    Vector3 localScale;
    // Start is called before the first frame update
    void Start () {
        localScale = transform.localScale;
    }

    public void DecreaseHealth (float percentage) {
        localScale.y -= (localScale.y * percentage);
        transform.localScale = localScale;
    }
}