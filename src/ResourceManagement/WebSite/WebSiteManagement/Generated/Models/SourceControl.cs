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
    /// Describes the Source Control OAuth Token
    /// </summary>
    public partial class SourceControl : Resource
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public SkuDescription Sku { get; set; }

        /// <summary>
        /// Name or Source Control Type
        /// </summary>
        [JsonProperty(PropertyName = "properties.name")]
        public string SourceControlName { get; set; }

        /// <summary>
        /// OAuth Access Token
        /// </summary>
        [JsonProperty(PropertyName = "properties.token")]
        public string Token { get; set; }

        /// <summary>
        /// OAuth Access Token Secret
        /// </summary>
        [JsonProperty(PropertyName = "properties.tokenSecret")]
        public string TokenSecret { get; set; }

        /// <summary>
        /// OAuth Refresh Token
        /// </summary>
        [JsonProperty(PropertyName = "properties.refreshToken")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// OAuth Token Expiration
        /// </summary>
        [JsonProperty(PropertyName = "properties.expirationTime")]
        public DateTime? ExpirationTime { get; set; }

    }
}
