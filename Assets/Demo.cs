using TMPro;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    public TextMeshProUGUI textbox;

    public void ButtonClickMethod()
    {
        textbox.text = "i have changed";
    }
}
