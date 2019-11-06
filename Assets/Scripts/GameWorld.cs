using UnityEngine;

//[ExecuteAlways]
public class GameWorld : MonoBehaviour {
    [SerializeField][Range(0.0001f,1.0f)] float targetScale = 1.0f;
    [SerializeField] float currentVelocity = 0.0f;
    [SerializeField] float smoothTime = 0.3f;
    [SerializeField] BackgroundPatternImage backgroundPatternImage = null;
    [SerializeField] float unitRepeatRatio = 400.0f;
    [SerializeField] Player player = null;
    [SerializeField] RectTransform endOfWorld = null;

    public float TargetScale {
        get => targetScale;
        private set => targetScale = value;
    }

    public float LocalScale {
        get => transform.localScale.x;
        set => transform.localScale = Vector3.one * value;
    }

    void Update() {
        LocalScale = Mathf.SmoothDamp(LocalScale, TargetScale, ref currentVelocity, smoothTime);
        backgroundPatternImage.RepeatRatio = unitRepeatRatio * LocalScale;

        if (player.RadiusXWorld / endOfWorld.position.x > 0.5f) {
            TargetScale /= 2;
        }
    }
}
