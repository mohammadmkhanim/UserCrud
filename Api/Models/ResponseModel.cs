using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Api.Models
{
    public class ResponseModel : ActionResult
    {
        private readonly int statusCode;
        private readonly object? value;
        private readonly List<string>? messages;

        public ResponseModel(int statusCode, object? value = null, List<string>? messages = null)
        {
            this.statusCode = statusCode;
            this.value = value;
            this.messages = messages;
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = statusCode;
            var responseObj = new
            {
                value = this.value,
                messages = this.messages,
                status = this.statusCode
            };
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var jsonResponse = JsonConvert.SerializeObject(responseObj, jsonSerializerSettings);
            await response.WriteAsync(jsonResponse);
        }

        public async Task ExecuteResultAsync(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = statusCode;
            var responseObj = new
            {
                value = this.value,
                messages = this.messages,
                status = this.statusCode
            };
            var jsonResponse = JsonConvert.SerializeObject(responseObj);
            await response.WriteAsync(jsonResponse);
        }

    }
}