// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.SiteRecovery
{
    /// <summary>
    /// Definition of event operations for the Site Recovery extension.
    /// </summary>
    internal partial class EventOperations : IServiceOperations<SiteRecoveryManagementClient>, IEventOperations
    {
        /// <summary>
        /// Initializes a new instance of the EventOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal EventOperations(SiteRecoveryManagementClient client)
        {
            this._client = client;
        }
        
        private SiteRecoveryManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.SiteRecovery.SiteRecoveryManagementClient.
        /// </summary>
        public SiteRecoveryManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Get the list of events under the vault.
        /// </summary>
        /// <param name='filter'>
        /// Optional. Filter for the events to be fetched.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response model for the list events operation.
        /// </returns>
        public async Task<EventListResponse> ListAsync(string filter, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("filter", filter);
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/Subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(this.Client.ResourceGroupName);
            url = url + "/providers/";
            url = url + Uri.EscapeDataString(this.Client.ResourceNamespace);
            url = url + "/";
            url = url + Uri.EscapeDataString(this.Client.ResourceType);
            url = url + "/";
            url = url + Uri.EscapeDataString(this.Client.ResourceName);
            url = url + "/replicationEvents";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2015-11-10");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept-Language", customRequestHeaders.Culture);
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                httpRequest.Headers.Add("x-ms-version", "2015-01-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    EventListResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new EventListResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    Event eventInstance = new Event();
                                    result.Events.Add(eventInstance);
                                    
                                    JToken propertiesValue = valueValue["properties"];
                                    if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                                    {
                                        EventProperties propertiesInstance = new EventProperties();
                                        eventInstance.Properties = propertiesInstance;
                                        
                                        JToken sourceIdValue = propertiesValue["sourceId"];
                                        if (sourceIdValue != null && sourceIdValue.Type != JTokenType.Null)
                                        {
                                            string sourceIdInstance = ((string)sourceIdValue);
                                            propertiesInstance.SourceId = sourceIdInstance;
                                        }
                                        
                                        JToken descriptionValue = propertiesValue["description"];
                                        if (descriptionValue != null && descriptionValue.Type != JTokenType.Null)
                                        {
                                            string descriptionInstance = ((string)descriptionValue);
                                            propertiesInstance.Description = descriptionInstance;
                                        }
                                        
                                        JToken eventTypeValue = propertiesValue["eventType"];
                                        if (eventTypeValue != null && eventTypeValue.Type != JTokenType.Null)
                                        {
                                            string eventTypeInstance = ((string)eventTypeValue);
                                            propertiesInstance.EventType = eventTypeInstance;
                                        }
                                        
                                        JToken affectedObjectNameValue = propertiesValue["affectedObjectName"];
                                        if (affectedObjectNameValue != null && affectedObjectNameValue.Type != JTokenType.Null)
                                        {
                                            string affectedObjectNameInstance = ((string)affectedObjectNameValue);
                                            propertiesInstance.AffectedObjectName = affectedObjectNameInstance;
                                        }
                                        
                                        JToken severityValue = propertiesValue["severity"];
                                        if (severityValue != null && severityValue.Type != JTokenType.Null)
                                        {
                                            string severityInstance = ((string)severityValue);
                                            propertiesInstance.Severity = severityInstance;
                                        }
                                        
                                        JToken timeOfOccurrenceValue = propertiesValue["timeOfOccurrence"];
                                        if (timeOfOccurrenceValue != null && timeOfOccurrenceValue.Type != JTokenType.Null)
                                        {
                                            DateTime timeOfOccurrenceInstance = ((DateTime)timeOfOccurrenceValue);
                                            propertiesInstance.TimeOfOccurrence = timeOfOccurrenceInstance;
                                        }
                                        
                                        JToken fabricNameValue = propertiesValue["fabricName"];
                                        if (fabricNameValue != null && fabricNameValue.Type != JTokenType.Null)
                                        {
                                            string fabricNameInstance = ((string)fabricNameValue);
                                            propertiesInstance.FabricName = fabricNameInstance;
                                        }
                                        
                                        JToken providerSpecificDetailsValue = propertiesValue["providerSpecificDetails"];
                                        if (providerSpecificDetailsValue != null && providerSpecificDetailsValue.Type != JTokenType.Null)
                                        {
                                            string typeName = ((string)providerSpecificDetailsValue["instanceType"]);
                                            if (typeName == "HyperVReplica2012")
                                            {
                                                HyperVReplica2012EventDetails hyperVReplica2012EventDetailsInstance = new HyperVReplica2012EventDetails();
                                                
                                                JToken containerNameValue = providerSpecificDetailsValue["containerName"];
                                                if (containerNameValue != null && containerNameValue.Type != JTokenType.Null)
                                                {
                                                    string containerNameInstance = ((string)containerNameValue);
                                                    hyperVReplica2012EventDetailsInstance.ContainerName = containerNameInstance;
                                                }
                                                
                                                JToken fabricNameValue2 = providerSpecificDetailsValue["fabricName"];
                                                if (fabricNameValue2 != null && fabricNameValue2.Type != JTokenType.Null)
                                                {
                                                    string fabricNameInstance2 = ((string)fabricNameValue2);
                                                    hyperVReplica2012EventDetailsInstance.FabricName = fabricNameInstance2;
                                                }
                                                
                                                JToken remoteContainerNameValue = providerSpecificDetailsValue["remoteContainerName"];
                                                if (remoteContainerNameValue != null && remoteContainerNameValue.Type != JTokenType.Null)
                                                {
                                                    string remoteContainerNameInstance = ((string)remoteContainerNameValue);
                                                    hyperVReplica2012EventDetailsInstance.RemoteContainerName = remoteContainerNameInstance;
                                                }
                                                
                                                JToken remoteFabricNameValue = providerSpecificDetailsValue["remoteFabricName"];
                                                if (remoteFabricNameValue != null && remoteFabricNameValue.Type != JTokenType.Null)
                                                {
                                                    string remoteFabricNameInstance = ((string)remoteFabricNameValue);
                                                    hyperVReplica2012EventDetailsInstance.RemoteFabricName = remoteFabricNameInstance;
                                                }
                                                
                                                JToken instanceTypeValue = providerSpecificDetailsValue["instanceType"];
                                                if (instanceTypeValue != null && instanceTypeValue.Type != JTokenType.Null)
                                                {
                                                    string instanceTypeInstance = ((string)instanceTypeValue);
                                                    hyperVReplica2012EventDetailsInstance.InstanceType = instanceTypeInstance;
                                                }
                                                propertiesInstance.ProviderDetails = hyperVReplica2012EventDetailsInstance;
                                            }
                                            if (typeName == "HyperVReplica2012R2")
                                            {
                                                HyperVReplica2012R2EventDetails hyperVReplica2012R2EventDetailsInstance = new HyperVReplica2012R2EventDetails();
                                                
                                                JToken instanceTypeValue2 = providerSpecificDetailsValue["instanceType"];
                                                if (instanceTypeValue2 != null && instanceTypeValue2.Type != JTokenType.Null)
                                                {
                                                    string instanceTypeInstance2 = ((string)instanceTypeValue2);
                                                    hyperVReplica2012R2EventDetailsInstance.InstanceType = instanceTypeInstance2;
                                                }
                                                propertiesInstance.ProviderDetails = hyperVReplica2012R2EventDetailsInstance;
                                            }
                                            if (typeName == "HyperVReplicaAzure")
                                            {
                                                HyperVReplicaAzureEventDetails hyperVReplicaAzureEventDetailsInstance = new HyperVReplicaAzureEventDetails();
                                                
                                                JToken containerNameValue2 = providerSpecificDetailsValue["containerName"];
                                                if (containerNameValue2 != null && containerNameValue2.Type != JTokenType.Null)
                                                {
                                                    string containerNameInstance2 = ((string)containerNameValue2);
                                                    hyperVReplicaAzureEventDetailsInstance.ContainerName = containerNameInstance2;
                                                }
                                                
                                                JToken fabricNameValue3 = providerSpecificDetailsValue["fabricName"];
                                                if (fabricNameValue3 != null && fabricNameValue3.Type != JTokenType.Null)
                                                {
                                                    string fabricNameInstance3 = ((string)fabricNameValue3);
                                                    hyperVReplicaAzureEventDetailsInstance.FabricName = fabricNameInstance3;
                                                }
                                                
                                                JToken remoteContainerNameValue2 = providerSpecificDetailsValue["remoteContainerName"];
                                                if (remoteContainerNameValue2 != null && remoteContainerNameValue2.Type != JTokenType.Null)
                                                {
                                                    string remoteContainerNameInstance2 = ((string)remoteContainerNameValue2);
                                                    hyperVReplicaAzureEventDetailsInstance.RemoteContainerName = remoteContainerNameInstance2;
                                                }
                                                
                                                JToken instanceTypeValue3 = providerSpecificDetailsValue["instanceType"];
                                                if (instanceTypeValue3 != null && instanceTypeValue3.Type != JTokenType.Null)
                                                {
                                                    string instanceTypeInstance3 = ((string)instanceTypeValue3);
                                                    hyperVReplicaAzureEventDetailsInstance.InstanceType = instanceTypeInstance3;
                                                }
                                                propertiesInstance.ProviderDetails = hyperVReplicaAzureEventDetailsInstance;
                                            }
                                            if (typeName == "VMwareAzureV2")
                                            {
                                                VMwareAzureV2EventDetails vMwareAzureV2EventDetailsInstance = new VMwareAzureV2EventDetails();
                                                
                                                JToken eventTypeValue2 = providerSpecificDetailsValue["eventType"];
                                                if (eventTypeValue2 != null && eventTypeValue2.Type != JTokenType.Null)
                                                {
                                                    string eventTypeInstance2 = ((string)eventTypeValue2);
                                                    vMwareAzureV2EventDetailsInstance.EventType = eventTypeInstance2;
                                                }
                                                
                                                JToken categoryValue = providerSpecificDetailsValue["category"];
                                                if (categoryValue != null && categoryValue.Type != JTokenType.Null)
                                                {
                                                    string categoryInstance = ((string)categoryValue);
                                                    vMwareAzureV2EventDetailsInstance.Category = categoryInstance;
                                                }
                                                
                                                JToken componentValue = providerSpecificDetailsValue["component"];
                                                if (componentValue != null && componentValue.Type != JTokenType.Null)
                                                {
                                                    string componentInstance = ((string)componentValue);
                                                    vMwareAzureV2EventDetailsInstance.Component = componentInstance;
                                                }
                                                
                                                JToken correctiveActionValue = providerSpecificDetailsValue["correctiveAction"];
                                                if (correctiveActionValue != null && correctiveActionValue.Type != JTokenType.Null)
                                                {
                                                    string correctiveActionInstance = ((string)correctiveActionValue);
                                                    vMwareAzureV2EventDetailsInstance.CorrectiveAction = correctiveActionInstance;
                                                }
                                                
                                                JToken detailsValue = providerSpecificDetailsValue["details"];
                                                if (detailsValue != null && detailsValue.Type != JTokenType.Null)
                                                {
                                                    string detailsInstance = ((string)detailsValue);
                                                    vMwareAzureV2EventDetailsInstance.Details = detailsInstance;
                                                }
                                                
                                                JToken summaryValue = providerSpecificDetailsValue["summary"];
                                                if (summaryValue != null && summaryValue.Type != JTokenType.Null)
                                                {
                                                    string summaryInstance = ((string)summaryValue);
                                                    vMwareAzureV2EventDetailsInstance.Summary = summaryInstance;
                                                }
                                                
                                                JToken siteNameValue = providerSpecificDetailsValue["siteName"];
                                                if (siteNameValue != null && siteNameValue.Type != JTokenType.Null)
                                                {
                                                    string siteNameInstance = ((string)siteNameValue);
                                                    vMwareAzureV2EventDetailsInstance.SiteName = siteNameInstance;
                                                }
                                                
                                                JToken instanceTypeValue4 = providerSpecificDetailsValue["instanceType"];
                                                if (instanceTypeValue4 != null && instanceTypeValue4.Type != JTokenType.Null)
                                                {
                                                    string instanceTypeInstance4 = ((string)instanceTypeValue4);
                                                    vMwareAzureV2EventDetailsInstance.InstanceType = instanceTypeInstance4;
                                                }
                                                propertiesInstance.ProviderDetails = vMwareAzureV2EventDetailsInstance;
                                            }
                                        }
                                        
                                        JToken healthErrorsArray = propertiesValue["healthErrors"];
                                        if (healthErrorsArray != null && healthErrorsArray.Type != JTokenType.Null)
                                        {
                                            foreach (JToken healthErrorsValue in ((JArray)healthErrorsArray))
                                            {
                                                HealthError healthErrorInstance = new HealthError();
                                                propertiesInstance.HealthErrors.Add(healthErrorInstance);
                                                
                                                JToken errorLevelValue = healthErrorsValue["errorLevel"];
                                                if (errorLevelValue != null && errorLevelValue.Type != JTokenType.Null)
                                                {
                                                    string errorLevelInstance = ((string)errorLevelValue);
                                                    healthErrorInstance.ErrorLevel = errorLevelInstance;
                                                }
                                                
                                                JToken errorCodeValue = healthErrorsValue["errorCode"];
                                                if (errorCodeValue != null && errorCodeValue.Type != JTokenType.Null)
                                                {
                                                    string errorCodeInstance = ((string)errorCodeValue);
                                                    healthErrorInstance.ErrorCode = errorCodeInstance;
                                                }
                                                
                                                JToken errorMessageValue = healthErrorsValue["errorMessage"];
                                                if (errorMessageValue != null && errorMessageValue.Type != JTokenType.Null)
                                                {
                                                    string errorMessageInstance = ((string)errorMessageValue);
                                                    healthErrorInstance.ErrorMessage = errorMessageInstance;
                                                }
                                                
                                                JToken possibleCausesValue = healthErrorsValue["possibleCauses"];
                                                if (possibleCausesValue != null && possibleCausesValue.Type != JTokenType.Null)
                                                {
                                                    string possibleCausesInstance = ((string)possibleCausesValue);
                                                    healthErrorInstance.PossibleCauses = possibleCausesInstance;
                                                }
                                                
                                                JToken recommendedActionValue = healthErrorsValue["recommendedAction"];
                                                if (recommendedActionValue != null && recommendedActionValue.Type != JTokenType.Null)
                                                {
                                                    string recommendedActionInstance = ((string)recommendedActionValue);
                                                    healthErrorInstance.RecommendedAction = recommendedActionInstance;
                                                }
                                                
                                                JToken creationTimeUtcValue = healthErrorsValue["creationTimeUtc"];
                                                if (creationTimeUtcValue != null && creationTimeUtcValue.Type != JTokenType.Null)
                                                {
                                                    string creationTimeUtcInstance = ((string)creationTimeUtcValue);
                                                    healthErrorInstance.CreationTimeUtc = creationTimeUtcInstance;
                                                }
                                                
                                                JToken recoveryProviderErrorMessageValue = healthErrorsValue["recoveryProviderErrorMessage"];
                                                if (recoveryProviderErrorMessageValue != null && recoveryProviderErrorMessageValue.Type != JTokenType.Null)
                                                {
                                                    string recoveryProviderErrorMessageInstance = ((string)recoveryProviderErrorMessageValue);
                                                    healthErrorInstance.RecoveryProviderErrorMessage = recoveryProviderErrorMessageInstance;
                                                }
                                                
                                                JToken entityIdValue = healthErrorsValue["entityId"];
                                                if (entityIdValue != null && entityIdValue.Type != JTokenType.Null)
                                                {
                                                    string entityIdInstance = ((string)entityIdValue);
                                                    healthErrorInstance.EntityId = entityIdInstance;
                                                }
                                            }
                                        }
                                    }
                                    
                                    JToken idValue = valueValue["id"];
                                    if (idValue != null && idValue.Type != JTokenType.Null)
                                    {
                                        string idInstance = ((string)idValue);
                                        eventInstance.Id = idInstance;
                                    }
                                    
                                    JToken nameValue = valueValue["name"];
                                    if (nameValue != null && nameValue.Type != JTokenType.Null)
                                    {
                                        string nameInstance = ((string)nameValue);
                                        eventInstance.Name = nameInstance;
                                    }
                                    
                                    JToken typeValue = valueValue["type"];
                                    if (typeValue != null && typeValue.Type != JTokenType.Null)
                                    {
                                        string typeInstance = ((string)typeValue);
                                        eventInstance.Type = typeInstance;
                                    }
                                    
                                    JToken locationValue = valueValue["location"];
                                    if (locationValue != null && locationValue.Type != JTokenType.Null)
                                    {
                                        string locationInstance = ((string)locationValue);
                                        eventInstance.Location = locationInstance;
                                    }
                                    
                                    JToken tagsSequenceElement = ((JToken)valueValue["tags"]);
                                    if (tagsSequenceElement != null && tagsSequenceElement.Type != JTokenType.Null)
                                    {
                                        foreach (JProperty property in tagsSequenceElement)
                                        {
                                            string tagsKey = ((string)property.Name);
                                            string tagsValue = ((string)property.Value);
                                            eventInstance.Tags.Add(tagsKey, tagsValue);
                                        }
                                    }
                                }
                            }
                            
                            JToken nextLinkValue = responseDoc["nextLink"];
                            if (nextLinkValue != null && nextLinkValue.Type != JTokenType.Null)
                            {
                                string nextLinkInstance = ((string)nextLinkValue);
                                result.NextLink = nextLinkInstance;
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
