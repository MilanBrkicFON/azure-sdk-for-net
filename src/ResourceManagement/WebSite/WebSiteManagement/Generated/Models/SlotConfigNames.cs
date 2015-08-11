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
    /// Class containing names for connection strings and application settings
    /// to be marked as sticky to the slot
    /// and not moved during swap operation
    /// This is valid for all deployment slots under the site
    /// </summary>
    public partial class SlotConfigNames : Resource
    {
        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sku")]
        public SkuDescription Sku { get; set; }

        /// <summary>
        /// List of connection string names
        /// </summary>
        [JsonProperty(PropertyName = "properties.connectionStringNames")]
        public IList<string> ConnectionStringNames { get; set; }

        /// <summary>
        /// List of application settings names
        /// </summary>
        [JsonProperty(PropertyName = "properties.appSettingNames")]
        public IList<string> AppSettingNames { get; set; }

    }
}
