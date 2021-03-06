﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using com.freeclimb.api;

namespace com.freeclimb.percl
{
    /// <summary>
    /// RemoveFromConference PerCL command.
    /// </summary>
    [JsonObject]
    public sealed class RemoveFromConference : PerCLCommand
    {
        [JsonProperty(PropertyName = "callId")]
        private string callId = string.Empty;

        /// <summary>
        /// Helper method to build a JSON string from a RemoveFromConference instance.
        /// </summary>
        /// <returns>A JSON string equivalent to the RemoveFromConference instance.</returns>
        /// <exception cref="FreeClimbJSONException">Thrown upon deserialize failure.</exception>
        public override string toJson()
        {
            try
            {
                JsonSerializer jsonSerializer = JsonSerializer.Create();
                jsonSerializer.NullValueHandling = NullValueHandling.Ignore;

                StringBuilder strb = new StringBuilder();
                jsonSerializer.Serialize(new StringWriter(strb), toKvp());

                return strb.ToString();
            }
            catch (Exception e)
            {
                throw new FreeClimbJSONException(e.Message);
            }
        }

        /// <summary>
        /// Creates RemoveFromConference PerCL with require fields. 
        /// </summary>
        /// <param name="callId">Call Id.</param>
        public RemoveFromConference(string callId)
        {
            this.callId = callId;
        }

        /// <summary>
        /// Retrieve the callId value.
        /// </summary>
        /// <returns>The callId value of the object.</returns>
        public string getCallId { get { return this.callId; } }

        /// <summary>
        /// Set the callId value.
        /// </summary>
        /// <param name="val">callId value.</param>
        public void setCallId(string val) { this.callId = val; }

        /// <summary>
        /// Retrieve the KVP Dictionary for the RemoveFromConference instance. 
        /// </summary>
        /// <returns>KVP Dictionary</returns>
        /// <exception cref="FreeClimbJSONException">Thrown upon deserialize failure.</exception>
        public override IDictionary<string, object> toKvp()
        {
            // change all properties with settings to a dictionary
            IDictionary<string, object> props = new Dictionary<string, object>();

            if (this.callId == string.Empty)
            {
                throw new FreeClimbJSONException("callId is a required parameter");
            }
            props.Add("callId", this.callId);

            IDictionary<string, object> command = new Dictionary<string, object>();
            command.Add("RemoveFromConference", props);

            return command;
        }
    }
}
