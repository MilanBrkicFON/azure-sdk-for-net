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
    /// Represents user crendentials used for publishing activity
    /// </summary>
    public partial class User : Resource
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public SkuDescription Sku { get; set; }

        /// <summary>
        /// Username (internal)
        /// </summary>
        [JsonProperty(PropertyName = "properties.name")]
        public string UserName { get; set; }

        /// <summary>
        /// Username used for publishing
        /// </summary>
        [JsonProperty(PropertyName = "properties.publishingUserName")]
        public string PublishingUserName { get; set; }

        /// <summary>
        /// Password used for publishing
        /// </summary>
        [JsonProperty(PropertyName = "properties.publishingPassword")]
        public string PublishingPassword { get; set; }

        /// <summary>
        /// Timestamp when publishing credentials were last modified (internal)
        /// </summary>
        [JsonProperty(PropertyName = "properties.lastUpdatedTime")]
        public DateTime? LastUpdatedTime { get; set; }

        /// <summary>
        /// User metadata (internal)
        /// </summary>
        [JsonProperty(PropertyName = "properties.metadata")]
        public string Metadata { get; set; }

        /// <summary>
        /// Indicates if user has been marked for deletion (internal)
        /// </summary>
        [JsonProperty(PropertyName = "properties.isDeleted")]
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// Url of SCM site (internal)
        /// </summary>
        [JsonProperty(PropertyName = "properties.scmUri")]
        public string ScmUri { get; set; }

    }
}
