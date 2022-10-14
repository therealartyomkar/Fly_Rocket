using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Dropdown))]
public class DropdownValueSaver : MonoBehaviour
{
    const string Prefname = "QualityValue";
    [SerializeField] private Dropdown _dropdown;
    void Awake()
    {
        _dropdown = GetComponent<Dropdown>();
        _dropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(Prefname, _dropdown.value);
            PlayerPrefs.Save();
        }));
    }
    private void Start()
    {
        _dropdown.value = PlayerPrefs.GetInt(Prefname, 3);
    }

}
