using System;

namespace Modio;

/// <summary>
/// The 3rd party authentication service that will be used after
/// the user agrees to the terms of use and consent to an account being created.
/// </summary>
public enum AuthService
{
    ///
    Steam,

    ///
    EpicGames,

    ///
    Gog,

    ///
    Itchio,

    ///
    Xbox,

    ///
    Switch,

    ///
    Oculus,

    ///
    Apple,

    ///
    Discord,
}

internal static class AuthServiceExtension
{
    public static string ToValue(this AuthService service)
    {
        switch (service)
        {
            case AuthService.Steam:
                return "steam";
            case AuthService.EpicGames:
                return "epicgames";
            case AuthService.Gog:
                return "gog";
            case AuthService.Itchio:
                return "itchio";
            case AuthService.Xbox:
                return "xbox";
            case AuthService.Switch:
                return "switch";
            case AuthService.Oculus:
                return "oculus";
            case AuthService.Apple:
                return "apple";
            case AuthService.Discord:
                return "discord";
        }
        throw new InvalidOperationException();
    }
}