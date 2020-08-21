using TMPro;
using UnityEngine;

public class StoryDialogButtonView : MonoBehaviour
{
    public delegate void OnButtonClickDelegate(int index);
    public OnButtonClickDelegate OnButtonClick;

    [SerializeField] private TMP_Text _caption;

    private string _text;
    public int index;

    // ------------------------------------------------------------------------------------------
    public void Init(string _text, int index)
    {
        this.index = index;
        _caption.text = _text;
    }
    
    // ------------------------------------------------------------------------------------------
    public void OnClick()
    {
        if (OnButtonClick != null)
            OnButtonClick(index);
    }
}
