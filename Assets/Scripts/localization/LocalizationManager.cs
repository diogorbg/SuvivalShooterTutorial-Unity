using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour {
    private static LocalizationManager singleton;

    public enum TLang {
        auto,
        en,
        pt
    }
    public TLang lang = TLang.auto;

    public LocalizationTable table;

    void Awake() {
        singleton = this;

        // Detecção da linguagem
        if (lang == TLang.auto) {
            singleton.lang = TLang.en;
            if (Application.systemLanguage == SystemLanguage.Portuguese)
                singleton.lang = TLang.pt;
        }
    }

    public static string getLocalizedValue(string key) {
        LocalizationData data = singleton.table.dados.Find(o => o.key.Equals(key));
        if (data == null)
            return "Key não exite!";

        if (singleton.lang == TLang.en)
            return data.en;
        else if (singleton.lang == TLang.pt)
            return data.pt;
        return "Lang não selecionada!";
    }
}
