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
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.Insights
{
    /// <summary>
    /// Operations for managing resources sku.
    /// </summary>
    internal partial class SkuOperations : IServiceOperations<InsightsManagementClient>, ISkuOperations
    {
        /// <summary>
        /// Initializes a new instance of the SkuOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal SkuOperations(InsightsManagementClient client)
        {
            this._client = client;
        }

        private InsightsManagementClient _client;

        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.Insights.InsightsManagementClient.
        /// </summary>
        public InsightsManagementClient Client
        {
            get { return this._client; }
        }

        /// <param name='resourceId'>
        /// Required. The resource id.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async Task<AntaresSkuGetResponse> GetAntaresCurrentSkuInternalAsync(string resourceId, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceId == null)
            {
                throw new ArgumentNullException("resourceId");
            }

            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceId", resourceId);
                TracingAdapter.Enter(invocationId, this, "GetAntaresCurrentSkuInternalAsync", tracingParameters);
            }

            // Construct URL
            string url = "/" + Uri.EscapeDataString(resourceId) + "?";
            url = url + "api-version=2014-04-01";
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
                httpRequest.Headers.Add("Accept", "application/json");

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
                    AntaresSkuGetResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new AntaresSkuGetResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }

                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken propertiesValue = responseDoc["properties"];
                            if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                            {
                                AntaresSku propertiesInstance = new AntaresSku();
                                result.Properties = propertiesInstance;

                                JToken skuValue = propertiesValue["sku"];
                                if (skuValue != null && skuValue.Type != JTokenType.Null)
                                {
                                    string skuInstance = ((string)skuValue);
                                    propertiesInstance.Sku = skuInstance;
                                }

                                JToken currentNumberOfWorkersValue = propertiesValue["currentNumberOfWorkers"];
                                if (currentNumberOfWorkersValue != null && currentNumberOfWorkersValue.Type != JTokenType.Null)
                                {
                                    int currentNumberOfWorkersInstance = ((int)currentNumberOfWorkersValue);
                                    propertiesInstance.CurrentNumberOfWorkers = currentNumberOfWorkersInstance;
                                }

                                JToken currentWorkerSizeValue = propertiesValue["currentWorkerSize"];
                                if (currentWorkerSizeValue != null && currentWorkerSizeValue.Type != JTokenType.Null)
                                {
                                    int currentWorkerSizeInstance = ((int)currentWorkerSizeValue);
                                    propertiesInstance.CurrentWorkerSize = currentWorkerSizeInstance;
                                }
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

        /// <param name='resourceId'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async Task<SkuUpdateResponse> UpdateAntaresCurrentSkuInternalAsync(string resourceId, AntaresSkuUpdateRequest parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (resourceId == null)
            {
                throw new ArgumentNullException("resourceId");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceId", resourceId);
                tracingParameters.Add("parameters", parameters);
                TracingAdapter.Enter(invocationId, this, "UpdateAntaresCurrentSkuInternalAsync", tracingParameters);
            }

            // Construct URL
            string url = "/" + Uri.EscapeDataString(resourceId) + "?";
            url = url + "api-version=2014-04-01";
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
                httpRequest.Method = new HttpMethod("PATCH");
                httpRequest.RequestUri = new Uri(url);

                // Set Headers
                httpRequest.Headers.Add("Accept", "application/json");

                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);

                // Serialize Request
                string requestContent = null;
                JToken requestDoc = null;

                JObject propertiesValue = new JObject();
                requestDoc = new JObject();
                requestDoc["properties"] = propertiesValue;

                if (parameters.Sku != null)
                {
                    propertiesValue["sku"] = parameters.Sku;
                }

                propertiesValue["workerSize"] = parameters.WorkerSize;

                propertiesValue["numberOfWorkers"] = parameters.NumberOfWorkers;

                requestContent = requestDoc.ToString(Newtonsoft.Json.Formatting.Indented);
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

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
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }

                    // Create Result
                    SkuUpdateResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new SkuUpdateResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }

                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
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