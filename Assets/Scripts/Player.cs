using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float targetScale = 1.0f;
    [SerializeField] float currentVelocity = 0.0f;
    [SerializeField] float smoothTime = 0.01f;
    [SerializeField] GameObject dotSplashPrefab = null;
    [SerializeField] RectTransform playerRadius = null;
    [SerializeField] GameWorld gameWorld = null;

    public float TargetScale {
        get => targetScale;
        private set => targetScale = value;
    }

    public float LocalScale {
        get => transform.localScale.x;
        private set => transform.localScale = Vector3.one * value;
    }

    public float RadiusWorld => (playerRadius.position - transform.position).magnitude;

    public float RadiusXWorld => playerRadius.position.x;

    void OnTriggerEnter2D(Collider2D collider) {

        var diffPos = collider.transform.position - transform.position;

        var diffRad = Mathf.Atan2(diffPos.y, diffPos.x);
        var dotSplash = Instantiate(dotSplashPrefab, transform.parent);
        var dotSplashPosition = diffPos.normalized * RadiusWorld;
        dotSplash.transform.position = new Vector3(dotSplashPosition.x, dotSplashPosition.y, dotSplash.transform.position.z);
        dotSplash.transform.rotation = Quaternion.Euler(0, 0, diffRad * Mathf.Rad2Deg - 90);
        Destroy(collider.gameObject);
        TargetScale += 0.1f;
    }

    void Update() {
        LocalScale = Mathf.SmoothDamp(LocalScale, TargetScale, ref currentVelocity, smoothTime);
    }
}
