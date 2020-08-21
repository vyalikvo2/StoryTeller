using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public Canvas canvas;
    public StoryDialogView dialogView;
    
    private StoryCachedViews _storyCachedViews;
    private StoryTree _storyTree;
    
    private StoryBackgroundView _currentBackgroundView;
    private StoryPersonView _currentPersonView;

    private StoryDialog _currentStoryDialog;
    private EmotionsLoader _emotionsLoader;

    // ------------------------------------------------------------------------------------------
    void Start()
    {
        _storyCachedViews = new StoryCachedViews();
        _storyTree = StoryTree.GetDefaultStoryTree();
        
        dialogView.Init(this);
        dialogView.gameObject.SetActive(false);
        
        _emotionsLoader = GetComponent<EmotionsLoader>();
        _emotionsLoader.OnLoadedImages = OnAllImagesLoaded;
        _emotionsLoader.Load();
    }

    // ------------------------------------------------------------------------------------------
    private void OnAllImagesLoaded()
    {
        dialogView.gameObject.SetActive(true);
        SetTreeView(Dialogs.DIALOG_1);
    }

    // ------------------------------------------------------------------------------------------
    public void SetTreeView(int dialogId)
    {
        Clean(dialogId);
        
        _currentStoryDialog = _storyTree.GetDialog(dialogId);
        
        Debug.Log("set background "+_currentStoryDialog.backgroundId);
        SetBackground(_currentStoryDialog.backgroundId);
        SetDialog(_currentStoryDialog.text, _currentStoryDialog.buttons);
        SetPerson(_currentStoryDialog.person);
    }

    // ------------------------------------------------------------------------------------------
    public void SetBackground(int bgId)
    {
        StoryBackgroundView bgView = _storyCachedViews.GetCachedBackground(bgId);

        // create and cache background instance if need
        if (bgView == null)
        {
            GameObject prefab = _storyCachedViews.GetBackgroundPrefab(bgId);
            GameObject go = Instantiate(prefab);
            go.name = "Background" + bgId;
            bgView = go.GetComponent<StoryBackgroundView>();
            bgView.Init();
            _storyCachedViews.SetCachedBackground(bgId, bgView);
        }
        
        bgView.gameObject.transform.parent = canvas.transform;
        bgView.AddedToStage();

        _currentBackgroundView = bgView;
    }
    
    // ------------------------------------------------------------------------------------------
    public void SetPerson(StoryPerson person)
    {
        if (person == null) return;
        
        StoryPersonView personView = _storyCachedViews.GetCachedPerson(person.personId);

        // create and cache background instance if need
        if (personView == null)
        {
            GameObject prefab = _storyCachedViews.GetPersonPrefab(person.personId);
            GameObject go = Instantiate(prefab);
            go.name = "person" + person.personId;
            personView = go.GetComponent<StoryPersonView>();
            personView.Init(_emotionsLoader.loadedFaces);
            _storyCachedViews.SetCachedPerson(person.personId, personView);
        }
        
        personView.SetEmotion(person.emotion);
        personView.gameObject.transform.parent = canvas.transform;

        switch (person.position)
        {
            case StoryPersonPosition.LEFT:
                RectTransform rect = personView.GetComponent<RectTransform>();
                rect.anchoredPosition = new Vector2(50,-50);
                //personView.transform.localPosition = new Vector3(50,-50,0);
                break;
        }

        _currentPersonView = personView;
    }

    // ------------------------------------------------------------------------------------------
    public void SetDialog(string text, List<StoryDialogButton> buttons)
    {
        dialogView.SetText(text);
        dialogView.SetButtons(buttons);
        dialogView.transform.SetAsLastSibling();
    }

    // ------------------------------------------------------------------------------------------
    public void OnButtonClick(int buttonIndex)
    {
        SetTreeView(_currentStoryDialog.buttons[buttonIndex].nextDialogId);
    }
    
    // ------------------------------------------------------------------------------------------
    // remove person or background if there is no this person at the next dialog
    public void Clean(int nextDialogId = -1)
    {
        if (_currentStoryDialog == null) return;
        StoryDialog nextDialog = _storyTree.GetDialog(nextDialogId);
        if (_currentStoryDialog.backgroundId != nextDialog.backgroundId)
        {
            _currentBackgroundView.transform.parent = null;
        }

        if (_currentStoryDialog.person != null)
        {
            if ((nextDialog.person !=null  && _currentStoryDialog.person.personId != nextDialog.person.personId) || nextDialog.person ==null)
            {
                _currentPersonView.transform.parent = null;
            }
        }
        
    }
}
