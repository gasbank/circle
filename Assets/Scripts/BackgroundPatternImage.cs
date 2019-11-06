using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class BackgroundPatternImage : MonoBehaviour {
    [SerializeField] RawImage rawImage = null;
    [SerializeField] float repeatRatio = 20.0f;

    public float RepeatRatio {
        get => repeatRatio;
        set => repeatRatio = value;
    }
    
    void Update() {
        var uvScale = new Vector2(Screen.width, Screen.height) / repeatRatio;
        var uvPosition = -0.5f * uvScale;
        rawImage.uvRect = new Rect(uvPosition, uvScale);
    }
}
