using UnityEngine;

public class StoryBackgroundView : MonoBehaviour
{
    private RectTransform rect;
    
    // ------------------------------------------------------------------------------------------
    public void Init()
    {
        rect = GetComponent<RectTransform>();
    }
    
    // ------------------------------------------------------------------------------------------
    public void AddedToStage()
    {
        rect.offsetMin = Vector2.zero;
        rect.offsetMax =  Vector2.zero;
    }
}
