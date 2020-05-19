using UnityEngine;

[CreateNodeMenu("Rule/InputKeyCodeRule")]
public class InputKeyCodeRule : BaseRule
{
    public override bool Valid => Input.GetKeyDown(keyCode);

    [SerializeField] private KeyCode keyCode = KeyCode.None;
}
