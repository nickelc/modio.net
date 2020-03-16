using System;
using System.Net.Http;

namespace Modio
{
    internal partial class Routes
    {
        #region Auth
        public static (HttpMethod, Uri) AuthEmailRequest()
        {
            return (HttpMethod.Post, new Uri("oauth/emailrequest", UriKind.Relative));
        }

        public static (HttpMethod, Uri) AuthEmailExchange()
        {
            return (HttpMethod.Post, new Uri("oauth/emailexchange", UriKind.Relative));
        }

        public static (HttpMethod, Uri) ExternalSteam()
        {
            return (HttpMethod.Post, new Uri("external/steamauth", UriKind.Relative));
        }

        public static (HttpMethod, Uri) ExternalGalaxy()
        {
            return (HttpMethod.Post, new Uri("external/galaxyauth", UriKind.Relative));
        }

        public static (HttpMethod, Uri) ExternalItchio()
        {
            return (HttpMethod.Post, new Uri("external/itchioauth", UriKind.Relative));
        }

        public static (HttpMethod, Uri) ExternalOculus()
        {
            return (HttpMethod.Post, new Uri("external/oculusauth", UriKind.Relative));
        }
        #endregion

        #region Game
        public static (HttpMethod, Uri) GetGames()
        {
            return (HttpMethod.Get, new Uri("games", UriKind.Relative));
        }

        public static (HttpMethod, Uri) GetGame(uint game)
        {
            var uri = "games/{0}".FormatUri(game);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) EditGame(uint game)
        {
            var uri = "games/{0}".FormatUri(game);
            return (HttpMethod.Put, uri);
        }

        public static (HttpMethod, Uri) AddGameMedia(uint game)
        {
            var uri = "games/{0}".FormatUri(game);
            return (HttpMethod.Post, uri);
        }

        public static (HttpMethod, Uri) GetGameTags(uint game)
        {
            var uri = "games/{0}/tags".FormatUri(game);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) AddGameTags(uint game)
        {
            var uri = "games/{0}/tags".FormatUri(game);
            return (HttpMethod.Post, uri);
        }

        public static (HttpMethod, Uri) DeleteGameTags(uint game)
        {
            var uri = "games/{0}/tags".FormatUri(game);
            return (HttpMethod.Delete, uri);
        }
        #endregion

        #region Mod
        public static (HttpMethod, Uri) GetMods(uint game)
        {
            var uri = "games/{0}/mods".FormatUri(game);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) GetMod(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}".FormatUri(game, mod);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) AddMod(uint game)
        {
            var uri = "games/{0}/mods".FormatUri(game);
            return (HttpMethod.Post, uri);
        }

        public static (HttpMethod, Uri) EditMod(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}".FormatUri(game, mod);
            return (HttpMethod.Put, uri);
        }

        public static (HttpMethod, Uri) DeleteMod(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}".FormatUri(game, mod);
            return (HttpMethod.Delete, uri);
        }
        #endregion

        #region Tags
        public static (HttpMethod, Uri) GetModTags(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/tags".FormatUri(game, mod);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) AddModTags(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/tags".FormatUri(game, mod);
            return (HttpMethod.Post, uri);
        }

        public static (HttpMethod, Uri) DeleteModTags(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/tags".FormatUri(game, mod);
            return (HttpMethod.Delete, uri);
        }
        #endregion

        #region Metadata
        public static (HttpMethod, Uri) GetModMetadata(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/metadatakvp".FormatUri(game, mod);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) AddModMetadata(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/metadatakvp".FormatUri(game, mod);
            return (HttpMethod.Post, uri);
        }

        public static (HttpMethod, Uri) DeleteModMetadata(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/metadatakvp".FormatUri(game, mod);
            return (HttpMethod.Delete, uri);
        }
        #endregion

        #region Dependencies
        public static (HttpMethod, Uri) GetModDependencies(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/dependencies".FormatUri(game, mod);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) AddModDependencies(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/dependencies".FormatUri(game, mod);
            return (HttpMethod.Post, uri);
        }

        public static (HttpMethod, Uri) DeleteModDependencies(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/dependencies".FormatUri(game, mod);
            return (HttpMethod.Delete, uri);
        }
        #endregion

        #region Media
        public static (HttpMethod, Uri) AddModMedia(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/media".FormatUri(game, mod);
            return (HttpMethod.Post, uri);
        }

        public static (HttpMethod, Uri) DeleteModMedia(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/media".FormatUri(game, mod);
            return (HttpMethod.Delete, uri);
        }
        #endregion

        #region Team
        public static (HttpMethod, Uri) GetTeamMembers(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/team".FormatUri(game, mod);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) AddTeamMember(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/team".FormatUri(game, mod);
            return (HttpMethod.Post, uri);
        }

        public static (HttpMethod, Uri) EditTeamMember(uint game, uint mod, uint member)
        {
            var uri = "games/{0}/mods/{1}/team/{2}".FormatUri(game, mod, member);
            return (HttpMethod.Put, uri);
        }

        public static (HttpMethod, Uri) DeleteTeamMember(uint game, uint mod, uint member)
        {
            var uri = "games/{0}/mods/{1}/team/{2}".FormatUri(game, mod, member);
            return (HttpMethod.Delete, uri);
        }
        #endregion

        #region Comments
        public static (HttpMethod, Uri) GetComments(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/comments".FormatUri(game, mod);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) GetComment(uint game, uint mod, uint comment)
        {
            var uri = "games/{0}/mods/{1}/comments/{2}".FormatUri(game, mod, comment);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) DeleteComment(uint game, uint mod, uint comment)
        {
            var uri = "games/{0}/mods/{1}/comments/{2}".FormatUri(game, mod, comment);
            return (HttpMethod.Delete, uri);
        }
        #endregion

        #region Events
        public static (HttpMethod, Uri) GetAllModEvents(uint game)
        {
            var uri = "games/{0}/mods/events".FormatUri(game);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) GetModEvents(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/events".FormatUri(game, mod);
            return (HttpMethod.Get, uri);
        }
        #endregion

        #region Stats
        public static (HttpMethod, Uri) GetAllModStats(uint game)
        {
            var uri = "games/{0}/mods/stats".FormatUri(game);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) GetModStats(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/stats".FormatUri(game, mod);
            return (HttpMethod.Get, uri);
        }
        #endregion

        #region Rate
        public static (HttpMethod, Uri) RateMod(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/ratings".FormatUri(game, mod);
            return (HttpMethod.Post, uri);
        }
        #endregion

        #region Subscribe
        public static (HttpMethod, Uri) Subscribe(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/subscribe".FormatUri(game, mod);
            return (HttpMethod.Post, uri);
        }

        public static (HttpMethod, Uri) Unsubscribe(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/subscribe".FormatUri(game, mod);
            return (HttpMethod.Delete, uri);
        }
        #endregion

        #region Files
        public static (HttpMethod, Uri) GetFiles(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/files".FormatUri(game, mod);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) GetFile(uint game, uint mod, uint file)
        {
            var uri = "games/{0}/mods/{1}/files/{2}".FormatUri(game, mod, file);
            return (HttpMethod.Get, uri);
        }

        public static (HttpMethod, Uri) AddFile(uint game, uint mod)
        {
            var uri = "games/{0}/mods/{1}/files".FormatUri(game, mod);
            return (HttpMethod.Post, uri);
        }

        public static (HttpMethod, Uri) EditFile(uint game, uint mod, uint file)
        {
            var uri = "games/{0}/mods/{1}/files/{2}".FormatUri(game, mod, file);
            return (HttpMethod.Put, uri);
        }

        public static (HttpMethod, Uri) DeleteFile(uint game, uint mod, uint file)
        {
            var uri = "games/{0}/mods/{1}/files/{2}".FormatUri(game, mod, file);
            return (HttpMethod.Delete, uri);
        }
        #endregion

        #region User
        public static (HttpMethod, Uri) CurrentUser()
        {
            return (HttpMethod.Get, new Uri("me", UriKind.Relative));
        }

        public static (HttpMethod, Uri) UserSubscriptions()
        {
            return (HttpMethod.Get, new Uri("me/subscribed", UriKind.Relative));
        }

        public static (HttpMethod, Uri) UserEvents()
        {
            return (HttpMethod.Get, new Uri("me/events", UriKind.Relative));
        }

        public static (HttpMethod, Uri) UserGames()
        {
            return (HttpMethod.Get, new Uri("me/games", UriKind.Relative));
        }

        public static (HttpMethod, Uri) UserMods()
        {
            return (HttpMethod.Get, new Uri("me/mods", UriKind.Relative));
        }

        public static (HttpMethod, Uri) UserFiles()
        {
            return (HttpMethod.Get, new Uri("me/files", UriKind.Relative));
        }

        public static (HttpMethod, Uri) UserRatings()
        {
            return (HttpMethod.Get, new Uri("me/ratings", UriKind.Relative));
        }
        #endregion
    }
}
