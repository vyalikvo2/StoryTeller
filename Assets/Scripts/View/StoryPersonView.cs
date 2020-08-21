using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryPersonView : MonoBehaviour
{
    public Image faceImage;
    
    private StoryPersonEmotion _emotion;
    
    private Dictionary<StoryPersonEmotion, Sprite> _emotionSprites;
    private bool _initialized = false;
    
    // ------------------------------------------------------------------------------------------
    public void Init(Dictionary<StoryPersonEmotion, Sprite> emotionSprites)
    {
        _emotionSprites = emotionSprites;
        _initialized = true;
    }
    
    // ------------------------------------------------------------------------------------------
    // TODO: CrossFade animation
    public void SetEmotion(StoryPersonEmotion emotion)
    {
        Debug.Log("try set emotion "+emotion);
        if (!_initialized) throw new Exception("Person not initialized");
        if (_emotion.Equals(emotion))
        {
            return;
        }
        _emotion = emotion;

        Debug.Log("Set emotion "+emotion);
        faceImage.sprite = GetEmotionSprite(_emotion);
    }
    
    // ------------------------------------------------------------------------------------------
    private Sprite GetEmotionSprite(StoryPersonEmotion emotion)
    {
        if (!_initialized) throw new Exception("Person not initialized");
        return _emotionSprites.ContainsKey(emotion) ? _emotionSprites[emotion] : null;
    }
    
}
