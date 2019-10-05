using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocalizationData {
    public string key;
    public string en;
    public string pt;
}

[CreateAssetMenu(fileName = "LocalizationTable", menuName = "Localization/NewLocalization")]
public class LocalizationTable : ScriptableObject {
    public List<LocalizationData> dados = new List<LocalizationData>();
}
