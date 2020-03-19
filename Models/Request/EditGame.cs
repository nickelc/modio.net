using System;
using System.Net.Http;

using Modio.Models;

namespace Modio
{
    /// <summary>
    /// Used to edit a Game.
    /// </summary>
    public class EditGame
    {
        /// <summary>
        /// Status of the game.
        /// </summary>
        public Status? Status { get; set; }

        /// <summary>
        /// Name of the game. Cannot exceed 80 characters.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Subdomain for the game on mod.io. For example: https://gamename.mod.io.
        /// </summary>
        public string? NameId { get; set; }

        /// <summary>
        /// Summary of the game.
        /// </summary>
        public string? Summary { get; set; }

        /// <summary>
        /// Instructions and links creators should follow to upload mods.
        /// </summary>
        public string? Instructions { get; set; }

        /// <summary>
        /// Link to a mod.io guide, the modding wiki or a page where modders can learn
        /// how to make and submit mods to the games profile.
        /// </summary>
        public Uri? InstructionsUrl { get; set; }

        /// <summary>
        /// Word used to describe user-generated content (mods, items, addons etc).
        /// </summary>
        public string? UgcName { get; set; }

        /// <summary>
        /// Presentation style of the game on the mod.io website.
        /// </summary>
        public PresentationOption? PresentationOption { get; set; }

        /// <summary>
        /// Submission process the modders must follow.
        /// </summary>
        public SubmissionOption? SubmissionOption { get; set; }

        /// <summary>
        /// Curation process the team follows to approve mods.
        /// </summary>
        public CurationOption? CurationOption { get; set; }

        /// <summary>
        /// Community features enabled on the mod.io website.
        /// </summary>
        public CommunityOptions? CommunityOptions { get; set; }

        /// <summary>
        /// Revenue capabilities mods can enable.
        /// </summary>
        public RevenueOptions? RevenueOptions { get; set; }

        /// <summary>
        /// Level of API access the game allows.
        /// </summary>
        public ApiAccessOptions? ApiAccessOptions { get; set; }

        /// <summary>
        /// Enable the maturity options mods can choose.
        /// </summary>
        public MaturityOptions? MaturityOptions { get; set; }

        internal HttpContent ToContent()
        {
            var parameters = new Parameters();
            if (Status is Status status)
            {
                parameters.Add("status", ((int)status).ToString());
            }
            if (Name is string name)
            {
                parameters.Add("name", name);
            }
            if (NameId is string nameId)
            {
                parameters.Add("name_id", nameId);
            }
            if (Summary is string summary)
            {
                parameters.Add("summary", summary);
            }
            if (Instructions is string instructions)
            {
                parameters.Add("instructions", instructions);
            }
            if (InstructionsUrl is Uri uri)
            {
                parameters.Add("instructions_url", uri.ToString());
            }
            if (UgcName is string ugcName)
            {
                parameters.Add("ugc_name", ugcName);
            }
            if (PresentationOption is PresentationOption presentation)
            {
                parameters.Add("presentation_option", ((int)presentation).ToString());
            }
            if (SubmissionOption is SubmissionOption submission)
            {
                parameters.Add("submission_option", ((int)submission).ToString());
            }
            if (CurationOption is CurationOption curation)
            {
                parameters.Add("curation_option", ((int)curation).ToString());
            }
            if (CommunityOptions is CommunityOptions community)
            {
                parameters.Add("community_options", ((int)community).ToString());
            }
            if (RevenueOptions is RevenueOptions revenue)
            {
                parameters.Add("revenue_options", ((int)revenue).ToString());
            }
            if (ApiAccessOptions is ApiAccessOptions apiAccess)
            {
                parameters.Add("api_access_options", ((int)apiAccess).ToString());
            }
            if (MaturityOptions is MaturityOptions maturity)
            {
                parameters.Add("maturity_options", ((int)maturity).ToString());
            }
            return parameters.ToContent();
        }
    }
}
