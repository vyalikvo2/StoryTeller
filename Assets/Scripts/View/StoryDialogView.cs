using System.Collections.Generic;
using CatSimulator.Utils;
using TMPro;
using UnityEngine;

public class StoryDialogView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    [SerializeField] private Transform _buttonsContainer;
    [SerializeField] private GameObject _buttonSlot;

    private List<StoryDialogButtonView> _renderedButtons;
    private StoryController _storyController;
    
    // ------------------------------------------------------------------------------------------
    public void Init(StoryController storyController)
    {
        _renderedButtons = new List<StoryDialogButtonView>();
        _storyController = storyController;
        _buttonSlot.transform.parent = null;
    }
    
    // ------------------------------------------------------------------------------------------
    public void SetText(string text)
    {
        _text.text = text;
        _text.RecalculateRectTransform();
    }
    
    // ------------------------------------------------------------------------------------------
    // TODO: Cache buttons (to optimize on recreate)
    public void SetButtons(List<StoryDialogButton> buttons)
    {
        ResetButtons();
        CreateButtons(buttons);
    }
    
    // ------------------------------------------------------------------------------------------
    public void CreateButtons(List<StoryDialogButton> buttons)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            GameObject buttonGO = Instantiate(_buttonSlot, Vector3.zero, Quaternion.identity, _buttonsContainer);
            StoryDialogButtonView buttonView = buttonGO.GetComponent<StoryDialogButtonView>();
            buttonView.Init(buttons[i].caption, i);
            buttonView.transform.localScale = Vector3.one;
            buttonView.OnButtonClick = OnButtonClick;
            _renderedButtons.Add(buttonView);
        }
    }
    
    // ------------------------------------------------------------------------------------------
    public void ResetButtons()
    {
        for (int i = 0; i < _renderedButtons.Count; i++)
        {
            Destroy(_renderedButtons[i].gameObject);
        }
        _renderedButtons.Clear();
    }
    
    // ------------------------------------------------------------------------------------------
    public void OnButtonClick(int index)
    {
        _storyController.OnButtonClick(index);
    }
}
