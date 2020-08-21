using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CatSimulator.Utils
{
    public static class ExtensionMethods
    {
        // -----------------------------------------------------------------
        // Some extra recalculations for correct TextMeshPro displaying with ContentSizeFilter
        public static void RecalculateRectTransform(this TMP_Text tmp)
        {
            //LayoutRebuilder.ForceRebuildLayoutImmediate(tmp.rectTransform); - add it if have nested text field background
            LayoutRebuilder.ForceRebuildLayoutImmediate(tmp.rectTransform.parent.GetComponent<RectTransform>());
        }
    }
}