using System;
using System.Collections.Generic;
using System.Net.Http;

using Modio.Models;

namespace Modio
{
    using Parameter = KeyValuePair<string, string>;

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
            var parameters = new List<Parameter>();
            if (Status is Status status)
            {
                parameters.Add(new Parameter("status", status.ToString()));
            }
            if (Name is string name)
            {
                parameters.Add(new Parameter("name", name));
            }
            if (NameId is string nameId)
            {
                parameters.Add(new Parameter("name_id", nameId));
            }
            if (Summary is string summary)
            {
                parameters.Add(new Parameter("summary", summary));
            }
            if (Instructions is string instructions)
            {
                parameters.Add(new Parameter("instructions", instructions));
            }
            if (InstructionsUrl is Uri uri)
            {
                parameters.Add(new Parameter("instructions_url", uri.ToString()));
            }
            if (UgcName is string ugcName)
            {
                parameters.Add(new Parameter("ugc_name", ugcName));
            }
            if (PresentationOption is PresentationOption presentation)
            {
                parameters.Add(new Parameter("presentation_option", presentation.ToString()));
            }
            if (SubmissionOption is SubmissionOption submission)
            {
                parameters.Add(new Parameter("submission_option", submission.ToString()));
            }
            if (CurationOption is CurationOption curation)
            {
                parameters.Add(new Parameter("curation_option", curation.ToString()));
            }
            if (CommunityOptions is CommunityOptions community)
            {
                parameters.Add(new Parameter("community_options", community.ToString()));
            }
            if (RevenueOptions is RevenueOptions revenue)
            {
                parameters.Add(new Parameter("revenue_options", revenue.ToString()));
            }
            if (ApiAccessOptions is ApiAccessOptions apiAccess)
            {
                parameters.Add(new Parameter("api_access_options", apiAccess.ToString()));
            }
            if (MaturityOptions is MaturityOptions maturity)
            {
                parameters.Add(new Parameter("maturity_options", maturity.ToString()));
            }
            return new FormUrlEncodedContent(parameters);
        }
    }
}
