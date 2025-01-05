using System.Collections.Generic;

public static class AbilityRegistry
{
    private static Dictionary<string, BaseAbility> registeredAbilities = new Dictionary<string, BaseAbility>();
    private static HashSet<BaseAbility> activeAbilities = new HashSet<BaseAbility>();

    public static void RegisterAbility(string id, BaseAbility ability) {
        if (!registeredAbilities.ContainsKey(id)) {
            registeredAbilities.Add(id, ability);
        }
    }

    public static T GetAbility<T>(string id) where T : BaseAbility {
        return registeredAbilities[id] as T;
    }
}
