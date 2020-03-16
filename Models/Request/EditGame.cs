using System;
using System.Net.Http;

using Modio.Models;

namespace Modio
{
    public class EditGame
    {
        public Status? Status { get; set; }

        public string? Name { get; set; }

        public string? NameId { get; set; }

        public string? Summary { get; set; }

        public string? Instructions { get; set; }

        public Uri? InstructionsUrl { get; set; }

        public string? UgcName { get; set; }

        public PresentationOption? PresentationOption { get; set; }

        public SubmissionOption? SubmissionOption { get; set; }

        public CurationOption? CurationOption { get; set; }

        public CommunityOptions? CommunityOptions { get; set; }

        public RevenueOptions? RevenueOptions { get; set; }

        public ApiAccessOptions? ApiAccessOptions { get; set; }

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
