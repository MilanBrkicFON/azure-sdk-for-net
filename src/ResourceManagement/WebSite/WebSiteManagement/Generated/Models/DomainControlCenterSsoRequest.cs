// Code generated by Microsoft (R) AutoRest Code Generator 0.11.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Single sign on request information for domain management
    /// </summary>
    public partial class DomainControlCenterSsoRequest
    {
        /// <summary>
        /// Url where the single sign on request is to be made
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Post parameter key
        /// </summary>
        [JsonProperty(PropertyName = "postParameterKey")]
        public string PostParameterKey { get; set; }

        /// <summary>
        /// Post parameter value. Client should use
        /// 'application/x-www-form-urlencoded' encoding for this value.
        /// </summary>
        [JsonProperty(PropertyName = "postParameterValue")]
        public string PostParameterValue { get; set; }

    }
}
