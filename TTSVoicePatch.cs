using System.Collections.Generic;
using System.Text;
using HarmonyLib;

namespace TTSRu;

[HarmonyPatch(typeof(PlayerAvatar))]
static class TTSVoicePatch
{
    [HarmonyPrefix, HarmonyPatch(nameof(PlayerAvatar.ChatMessageSend))]
    private static void TranslateSpecialLetters_Prefix(ref string _message)
    {
        _message = ReplaceTokensNoCascade(_message, TTSRu.TOKENS);
    }
    
    public static string ReplaceTokensNoCascade(string text, IReadOnlyDictionary<char, string> tokens)
    {
        if (string.IsNullOrEmpty(text) || tokens.Count == 0)
        {
            return text;
        }

        var sb = new StringBuilder(text.Length);

        foreach (char ch in text)
        {
            if (tokens.TryGetValue(ch, out var rep)) sb.Append(rep);
            else sb.Append(ch);
        }

        return sb.ToString();
    }
}