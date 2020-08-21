using System.Collections.Generic;
using UnityEngine;

// backgrounds and persons
public class StoryCachedViews
{
    private Dictionary<int, GameObject> _prefBackgrounds;
    private Dictionary<int, GameObject> _prefPersons;
    
    private Dictionary<int, StoryBackgroundView> _backgrounds; 
    private Dictionary<int, StoryPersonView> _persons; 
    
    // ------------------------------------------------------------------------------------------
    public StoryCachedViews()
    {
        _prefBackgrounds = new Dictionary<int, GameObject>();
        _prefPersons = new Dictionary<int, GameObject>();
        
        _backgrounds = new Dictionary<int, StoryBackgroundView>();
        _persons = new Dictionary<int, StoryPersonView>();
    }
    
    // ------------------------------------------------------------------------------------------
    // ------------------- Person
    public GameObject GetPersonPrefab(int id)
    {
        if (!_prefPersons.ContainsKey(id))
        {
            GameObject go = Resources.Load("Prefabs/Persons/"+id) as GameObject;
            _prefPersons[id] = go;
            
            Debug.Log(go);
        }

        return _prefPersons[id];
    }
    
    // ------------------------------------------------------------------------------------------
    public StoryPersonView GetCachedPerson(int id)
    {
        if (!_persons.ContainsKey(id)) return null;
        return _persons[id];
    }
    
    // ------------------------------------------------------------------------------------------
    public void SetCachedPerson(int id, StoryPersonView personView)
    {
        _persons[id] = personView;
    }
    
    // ------------------------------------------------------------------------------------------
    // ----------------------- BACKGROUND
    public GameObject GetBackgroundPrefab(int id)
    {
        if (!_prefBackgrounds.ContainsKey(id))
        {
            GameObject bg = Resources.Load("Prefabs/Backgrounds/"+id) as GameObject;
            _prefBackgrounds[id] = bg;
            
            Debug.Log(bg);
        }

        return _prefBackgrounds[id];
    }
    
    // ------------------------------------------------------------------------------------------
    public StoryBackgroundView GetCachedBackground(int id)
    {
        if (!_backgrounds.ContainsKey(id)) return null;
        return _backgrounds[id];
    }
    
    // ------------------------------------------------------------------------------------------
    public void SetCachedBackground(int id, StoryBackgroundView bgView)
    {
        _backgrounds[id] = bgView;
    }

}
