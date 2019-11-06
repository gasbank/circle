using System.Collections;
using UnityEngine;

public class DotHelper : MonoBehaviour {
    [SerializeField] float targetScale = 1.0f;
    [SerializeField] float currentVelocity = 0.0f;
    [SerializeField] float smoothTime = 0.3f;
    [SerializeField] DotSpawner dotSpawner = null;
    [SerializeField] Transform dotHelperRadius = null;
    [SerializeField] float spawnInterval = 0.5f;

    public float TargetScale {
        get => targetScale;
        private set => targetScale = value;
    }

    public float LocalScale {
        get => transform.localScale.x;
        private set => transform.localScale = Vector3.one * value;
    }

    public float RadiusWorld => (dotHelperRadius.position - transform.position).magnitude;
    
    IEnumerator Start() {
        yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
        while (TargetScale > 0) {
            yield return new WaitForSeconds(spawnInterval);
            dotSpawner.SpawnNewDot(transform.position + (dotSpawner.Player.transform.position - transform.position).normalized * RadiusWorld);
            TargetScale -= 0.1f;
        }
        Destroy(gameObject);
    }

    void Update() {
        LocalScale = Mathf.SmoothDamp(LocalScale, TargetScale, ref currentVelocity, smoothTime);
    }
}
