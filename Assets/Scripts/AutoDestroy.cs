using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
    public float time;

    IEnumerator Start() {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
