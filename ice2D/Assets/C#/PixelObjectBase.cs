using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelObjectBase : MonoBehaviour {
    private Vector3 cashposition;

    private void LateUpdate()
    {
        cashposition = transform.localPosition;
        transform.localPosition = new Vector3(
            Mathf.RoundToInt(cashposition.x),
            Mathf.RoundToInt(cashposition.y),
            Mathf.RoundToInt(cashposition.z)
            );
    }

    private void OnRenderObject()
    {
        transform.localPosition = cashposition;
    }
}
