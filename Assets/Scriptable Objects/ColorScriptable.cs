using UnityEngine;

[CreateAssetMenu(menuName = "Snake Color")]
public class ColorScriptable : ScriptableObject
{
    [SerializeField] Color headColor;
    [SerializeField] Color bodyColor;
}
