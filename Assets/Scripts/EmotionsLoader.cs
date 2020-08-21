using System.Collections.Generic;
using UnityEngine;

public class EmotionsLoader : MonoBehaviour
{
    public delegate void OnLoadedImagesDelegate();

    public OnLoadedImagesDelegate OnLoadedImages;
    
    public Dictionary<StoryPersonEmotion, Sprite> loadedFaces;

    public List<string> textureURls = new List<string> {
        "https://picsum.photos/200", // 0
        "https://picsum.photos/200" // 1
    };

    private int _loadIndex = 0;
    private bool _isLoaded = false;
    
    // ------------------------------------------------------------------------------------------
    public bool IsLoaded()
    {
        return _isLoaded;
    }
    
    // ------------------------------------------------------------------------------------------
    public void Load()
    {
        LoadNext();
    }
    
    // ------------------------------------------------------------------------------------------
    private void LoadNext()
    {
        StartCoroutine(LoadImage(textureURls[_loadIndex])); 
    }
    
    // ------------------------------------------------------------------------------------------
    IEnumerator<WWW> LoadImage(string url) 
    {
        Texture2D texture = null;
        WWW www = new WWW(url);
        yield return www;

        texture = www.texture;
        Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f) );
        if (loadedFaces == null)
        {
            loadedFaces = new Dictionary<StoryPersonEmotion, Sprite>();
        }

        //TODO: move to another mapping method
        StoryPersonEmotion emotionKey;
        switch (_loadIndex)
        {
            case 0:
                emotionKey = StoryPersonEmotion.NORMAL;
                break;
            case 1:
                emotionKey = StoryPersonEmotion.WOW;
                break;
            default:
                emotionKey = StoryPersonEmotion.NORMAL;
                break;
        }
        loadedFaces[emotionKey] = sprite;

        if (_loadIndex < textureURls.Count-1)
        {
            _loadIndex++;
            LoadNext();
        }
        else
        {
            _isLoaded = true;
            if (OnLoadedImages != null) OnLoadedImages();
        }
    }
}