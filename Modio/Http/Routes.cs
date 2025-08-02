using System;
using System.Net.Http;

namespace Modio.Http;

internal static partial class Routes
{
    static Uri Uri(string uriString)
    {
        return new Uri(uriString, UriKind.Relative);
    }

    #region Auth
    public static (HttpMethod, Uri) AuthEmailRequest()
    {
        return (HttpMethod.Post, Uri("oauth/emailrequest"));
    }

    public static (HttpMethod, Uri) AuthEmailExchange()
    {
        return (HttpMethod.Post, Uri("oauth/emailexchange"));
    }

    public static (HttpMethod, Uri) Terms()
    {
        return (HttpMethod.Get, Uri("authenticate/terms"));
    }

    public static (HttpMethod, Uri) ExternalSteam()
    {
        return (HttpMethod.Post, Uri("external/steamauth"));
    }

    public static (HttpMethod, Uri) ExternalEpicGames()
    {
        return (HttpMethod.Post, Uri("external/epicgamesauth"));
    }

    public static (HttpMethod, Uri) ExternalGalaxy()
    {
        return (HttpMethod.Post, Uri("external/galaxyauth"));
    }

    public static (HttpMethod, Uri) ExternalItchio()
    {
        return (HttpMethod.Post, Uri("external/itchioauth"));
    }

    public static (HttpMethod, Uri) ExternalOculus()
    {
        return (HttpMethod.Post, Uri("external/oculusauth"));
    }

    public static (HttpMethod, Uri) ExternalXbox()
    {
        return (HttpMethod.Post, Uri("external/xboxauth"));
    }

    public static (HttpMethod, Uri) ExternalSwitch()
    {
        return (HttpMethod.Post, Uri("external/switchauth"));
    }

    public static (HttpMethod, Uri) ExternalApple()
    {
        return (HttpMethod.Post, Uri("external/appleauth"));
    }

    public static (HttpMethod, Uri) ExternalDiscord()
    {
        return (HttpMethod.Post, Uri("external/discordauth"));
    }
    #endregion

    #region Game
    public static (HttpMethod, Uri) GetGames()
    {
        return (HttpMethod.Get, Uri("games"));
    }

    public static (HttpMethod, Uri) GetGame(uint game)
    {
        return (HttpMethod.Get, Uri($"games/{game}"));
    }

    public static (HttpMethod, Uri) EditGame(uint game)
    {
        return (HttpMethod.Put, Uri($"games/{game}"));
    }

    public static (HttpMethod, Uri) AddGameMedia(uint game)
    {
        return (HttpMethod.Post, Uri($"games/{game}"));
    }

    public static (HttpMethod, Uri) GetGameTags(uint game)
    {
        return (HttpMethod.Get, Uri($"games/{game}/tags"));
    }

    public static (HttpMethod, Uri) AddGameTags(uint game)
    {
        return (HttpMethod.Post, Uri($"games/{game}/tags"));
    }

    public static (HttpMethod, Uri) DeleteGameTags(uint game)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/tags"));
    }
    #endregion

    #region Mod
    public static (HttpMethod, Uri) GetMods(uint game)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods"));
    }

    public static (HttpMethod, Uri) GetMod(uint game, uint mod)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}"));
    }

    public static (HttpMethod, Uri) AddMod(uint game)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods"));
    }

    public static (HttpMethod, Uri) EditMod(uint game, uint mod)
    {
        return (HttpMethod.Put, Uri($"games/{game}/mods/{mod}"));
    }

    public static (HttpMethod, Uri) DeleteMod(uint game, uint mod)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/mods/{mod}"));
    }
    #endregion

    #region Tags
    public static (HttpMethod, Uri) GetModTags(uint game, uint mod)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/tags"));
    }

    public static (HttpMethod, Uri) AddModTags(uint game, uint mod)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/tags"));
    }

    public static (HttpMethod, Uri) DeleteModTags(uint game, uint mod)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/mods/{mod}/tags"));
    }
    #endregion

    #region Metadata
    public static (HttpMethod, Uri) GetModMetadata(uint game, uint mod)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/metadatakvp"));
    }

    public static (HttpMethod, Uri) AddModMetadata(uint game, uint mod)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/metadatakvp"));
    }

    public static (HttpMethod, Uri) DeleteModMetadata(uint game, uint mod)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/mods/{mod}/metadatakvp"));
    }
    #endregion

    #region Dependencies
    public static (HttpMethod, Uri) GetModDependencies(uint game, uint mod, bool recursive)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/dependencies?recursive={recursive}"));
    }

    public static (HttpMethod, Uri) AddModDependencies(uint game, uint mod)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/dependencies"));
    }

    public static (HttpMethod, Uri) DeleteModDependencies(uint game, uint mod)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/mods/{mod}/dependencies"));
    }
    #endregion

    #region Media
    public static (HttpMethod, Uri) AddModMedia(uint game, uint mod)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/media"));
    }

    public static (HttpMethod, Uri) DeleteModMedia(uint game, uint mod)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/mods/{mod}/media"));
    }
    #endregion

    #region Team
    public static (HttpMethod, Uri) GetTeamMembers(uint game, uint mod)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/team"));
    }

    public static (HttpMethod, Uri) AddTeamMember(uint game, uint mod)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/team"));
    }

    public static (HttpMethod, Uri) EditTeamMember(uint game, uint mod, uint member)
    {
        return (HttpMethod.Put, Uri($"games/{game}/mods/{mod}/team/{member}"));
    }

    public static (HttpMethod, Uri) DeleteTeamMember(uint game, uint mod, uint member)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/mods/{mod}/team/{member}"));
    }
    #endregion

    #region Comments
    public static (HttpMethod, Uri) GetComments(uint game, uint mod)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/comments"));
    }

    public static (HttpMethod, Uri) GetComment(uint game, uint mod, uint comment)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/comments/{comment}"));
    }

    public static (HttpMethod, Uri) AddComment(uint game, uint mod)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/comments"));
    }

    public static (HttpMethod, Uri) EditComment(uint game, uint mod, uint comment)
    {
        return (HttpMethod.Put, Uri($"games/{game}/mods/{mod}/comments/{comment}"));
    }

    public static (HttpMethod, Uri) DeleteComment(uint game, uint mod, uint comment)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/mods/{mod}/comments/{comment}"));
    }
    #endregion

    #region Events
    public static (HttpMethod, Uri) GetAllModEvents(uint game)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/events"));
    }

    public static (HttpMethod, Uri) GetModEvents(uint game, uint mod)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/events"));
    }
    #endregion

    #region Stats
    public static (HttpMethod, Uri) GetAllModStats(uint game)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/stats"));
    }

    public static (HttpMethod, Uri) GetModStats(uint game, uint mod)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/stats"));
    }
    #endregion

    #region Rate
    public static (HttpMethod, Uri) RateMod(uint game, uint mod)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/ratings"));
    }
    #endregion

    #region Subscribe
    public static (HttpMethod, Uri) Subscribe(uint game, uint mod)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/subscribe"));
    }

    public static (HttpMethod, Uri) Unsubscribe(uint game, uint mod)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/mods/{mod}/subscribe"));
    }
    #endregion

    #region Files
    public static (HttpMethod, Uri) GetFiles(uint game, uint mod)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/files"));
    }

    public static (HttpMethod, Uri) GetFile(uint game, uint mod, uint file)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/files/{file}"));
    }

    public static (HttpMethod, Uri) AddFile(uint game, uint mod)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/files"));
    }

    public static (HttpMethod, Uri) EditFile(uint game, uint mod, uint file)
    {
        return (HttpMethod.Put, Uri($"games/{game}/mods/{mod}/files/{file}"));
    }

    public static (HttpMethod, Uri) DeleteFile(uint game, uint mod, uint file)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/mods/{mod}/files/{file}"));
    }

    public static (HttpMethod, Uri) EditPlatformStatus(uint game, uint mod, uint file)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/files/{file}/platforms"));
    }

    public static (HttpMethod, Uri) GetUploadSessions(uint game, uint mod)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/files/multipart/sessions"));
    }

    public static (HttpMethod, Uri) CreateUploadSession(uint game, uint mod)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/files/multipart"));
    }

    public static (HttpMethod, Uri) DeleteUploadSession(uint game, uint mod, Guid uploadId)
    {
        return (HttpMethod.Delete, Uri($"games/{game}/mods/{mod}/files/multipart?upload_id={uploadId}"));
    }

    public static (HttpMethod, Uri) CompleteUploadSession(uint game, uint mod, Guid uploadId)
    {
        return (HttpMethod.Post, Uri($"games/{game}/mods/{mod}/files/multipart/complete?upload_id={uploadId}"));
    }

    public static (HttpMethod, Uri) GetUploadParts(uint game, uint mod, Guid uploadId)
    {
        return (HttpMethod.Get, Uri($"games/{game}/mods/{mod}/files/multipart?upload_id={uploadId}"));
    }

    public static (HttpMethod, Uri) AddUploadPart(uint game, uint mod, Guid uploadId)
    {
        return (HttpMethod.Put, Uri($"games/{game}/mods/{mod}/files/multipart?upload_id={uploadId}"));
    }
    #endregion

    #region User
    public static (HttpMethod, Uri) CurrentUser()
    {
        return (HttpMethod.Get, Uri("me"));
    }

    public static (HttpMethod, Uri) UserSubscriptions()
    {
        return (HttpMethod.Get, Uri("me/subscribed"));
    }

    public static (HttpMethod, Uri) UserEvents()
    {
        return (HttpMethod.Get, Uri("me/events"));
    }

    public static (HttpMethod, Uri) UserGames()
    {
        return (HttpMethod.Get, Uri("me/games"));
    }

    public static (HttpMethod, Uri) UserMods()
    {
        return (HttpMethod.Get, Uri("me/mods"));
    }

    public static (HttpMethod, Uri) UserFiles()
    {
        return (HttpMethod.Get, Uri("me/files"));
    }

    public static (HttpMethod, Uri) UserRatings()
    {
        return (HttpMethod.Get, Uri("me/ratings"));
    }
    #endregion

    public static (HttpMethod, Uri) SubmitReport()
    {
        return (HttpMethod.Post, Uri("report"));
    }
}