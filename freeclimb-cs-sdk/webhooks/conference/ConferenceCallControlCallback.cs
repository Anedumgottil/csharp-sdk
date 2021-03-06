﻿using Newtonsoft.Json;
using System;
using System.IO;
using com.freeclimb.api;

namespace com.freeclimb.webhooks.conference
{
    /// <summary>
    /// A ConferenceCallControlCallback represents the JSON object that is 
    /// sent to the webhooks of FreeClimb applications.
    /// </summary>
    [JsonObject]
    public sealed class ConferenceCallControlCallback : VoiceRequest
    {
#pragma warning disable 0649 // default value compiler warning
        [JsonProperty(PropertyName = "digits")]
        private readonly string digits;
#pragma warning restore 0649

        /// <summary>
        /// Helper method to build a ConferenceCallControlCallback object from the JSON string.
        /// </summary>
        /// <param name="rawJson">A JSON string representing a ConferenceCallControlCallback instance.</param>
        /// <returns>A ConferenceCallControlCallback object equivalent to the JSON string passed in.</returns>
        /// <exception cref="FreeClimbJSONException">Thrown upon deserialize failure.</exception>
        public new static ConferenceCallControlCallback fromJson(string rawJson)
        {
            try
            {
                JsonSerializer jsonSerializer = JsonSerializer.Create();
                jsonSerializer.NullValueHandling = NullValueHandling.Ignore;

                return jsonSerializer.Deserialize<ConferenceCallControlCallback>(new JsonTextReader(new StringReader(rawJson)));
            }
            catch (Exception e)
            {
                throw new FreeClimbJSONException(e.Message);
            }
        }

        /// <summary>
        /// Retrieve digits value from the object.
        /// </summary>
        /// <returns>The digits value.</returns>
        public string getDigits { get { return this.digits; } }
    }
}
