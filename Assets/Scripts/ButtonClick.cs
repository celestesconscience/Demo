using TMPro; //Pulling from TextMesh Pro library
using UnityEngine; //Using Unity's Programming tools

//ButtonClick Class and Functions
public class ButtonClick : MonoBehaviour // <-- MonoBehaviour allows Unity to attach script to a GameObject
{

    public TextMeshProUGUI textbox; // 'TextMeshProUGUI' = type; 'textbox' = variable (stores a reference to a TextMesh Pro UI text object)

    public void ButtonClickMethod() // 'void' = return type; 'ButtonClickMethod' = method name (a named set of instructions that does something)
    {
        textbox.text = "i have changed"; // Change the text displayed by textbox to "i have changed".
    }
}
