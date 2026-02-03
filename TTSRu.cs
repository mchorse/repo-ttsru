using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace TTSRu;

[BepInPlugin("McHorse.TTSRu", "TTSRu", "1.0.1")]
public class TTSRu : BaseUnityPlugin
{
    public static readonly Dictionary<char, string> TOKENS = new()
    {
        ['А'] = "AA",  ['а'] = "aa",
        ['Б'] = "B",   ['б'] = "b",
        ['В'] = "V",   ['в'] = "v",
        ['Г'] = "G",   ['г'] = "g",
        ['Д'] = "D",   ['д'] = "d",
        ['Е'] = "EH",  ['е'] = "eh",
        ['Ё'] = "YO",  ['ё'] = "yo",
        ['Ж'] = "ZH",  ['ж'] = "zh",
        ['З'] = "Z",   ['з'] = "z",
        ['И'] = "EE",  ['и'] = "ee",
        ['Й'] = "Y",   ['й'] = "y",
        ['К'] = "K",   ['к'] = "k",
        ['Л'] = "L",   ['л'] = "l",
        ['М'] = "M",   ['м'] = "m",
        ['Н'] = "N",   ['н'] = "n",
        ['О'] = "OH",  ['о'] = "oh",
        ['П'] = "P",   ['п'] = "p",
        ['Р'] = "R",   ['р'] = "r",
        ['С'] = "S",   ['с'] = "s",
        ['Т'] = "T",   ['т'] = "t",
        ['У'] = "OO",  ['у'] = "oo",
        ['Ф'] = "F",   ['ф'] = "f",
        ['Х'] = "H",   ['х'] = "h",
        ['Ц'] = "TS",  ['ц'] = "ts",
        ['Ч'] = "CH",  ['ч'] = "ch",
        ['Ш'] = "SS",  ['ш'] = "sh",
        ['Щ'] = "SH",  ['щ'] = "sh",
        ['Ъ'] = "",    ['ъ'] = "",
        ['Ы'] = "EEH", ['ы'] = "eeh",
        ['Ь'] = "",    ['ь'] = "",
        ['Э'] = "AY",  ['э'] = "ay",
        ['Ю'] = "OO",  ['ю'] = "oo",
        ['Я'] = "YA",  ['я'] = "ya",
    };
    
    internal static TTSRu Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger => Instance._logger;
    private ManualLogSource _logger => base.Logger;
    internal Harmony? Harmony { get; set; }

    private void Awake()
    {
        Instance = this;
        
        // Prevent the plugin from being deleted
        this.gameObject.transform.parent = null;
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;

        Patch();

        Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");
    }

    internal void Patch()
    {
        Harmony ??= new Harmony(Info.Metadata.GUID);
        Harmony.PatchAll();
    }

    internal void Unpatch()
    {
        Harmony?.UnpatchSelf();
    }
}