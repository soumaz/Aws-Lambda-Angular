using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Runtime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CGISecuredRESTServicesWeb.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("api/register")]
        public async Task<ActionResult<string>> Register([FromBody] User user)
        {
            var status = string.Empty;
            var clientId = "20jo0qhegstp7ovimab8nln5pg";
            var awsCredentials = new BasicAWSCredentials(
                accessKey: "AKIAJLCJTGLJZ67AAAZA",
                secretKey: "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");

            try
            {
                var signupRequest = new SignUpRequest
                {
                    Username = user.UserName,
                    Password = user.Password,
                    ClientId = clientId,
                };

                var emailAttribute = new AttributeType { Name = "email", Value = user.Email };

                signupRequest.UserAttributes.Add(emailAttribute);

                using (var client = new AmazonCognitoIdentityProviderClient(awsCredentials, RegionEndpoint.APSoutheast1))
                {
                    var response = await client.SignUpAsync(signupRequest);

                    status = response.HttpStatusCode == System.Net.HttpStatusCode.OK ? "OK" : "ERROR";
                }
            }
            catch (Exception exceptionObject)
            {
                throw exceptionObject;
            }

            return Ok(status);
        }

        [HttpPost("api/signin")]
        public async Task<ActionResult<string>> Signin([FromBody] User user)
        {
            var validation = user != default(User) &&
                !string.IsNullOrEmpty(user.UserName) &&
                !string.IsNullOrEmpty(user.Password);

            if (!validation)
                return BadRequest();

            var token = string.Empty;
            var clientId = "20jo0qhegstp7ovimab8nln5pg";
            var userPoolId = @"ap-southeast-1_TarRBIFR7";
            var awsCredentials = new BasicAWSCredentials(
                accessKey: "AKIAJLCJTGLJZ67AAAZA",
                secretKey: "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");

            try
            {
                var authenticationRequest = new AdminInitiateAuthRequest
                {
                    UserPoolId = userPoolId,
                    ClientId = clientId,
                    AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH
                };

                authenticationRequest.AuthParameters.Add("USERNAME", user.UserName);
                authenticationRequest.AuthParameters.Add("PASSWORD", user.Password);

                using (var client =
                    new AmazonCognitoIdentityProviderClient(awsCredentials, RegionEndpoint.APSouth1))
                {
                    var response = await client.AdminInitiateAuthAsync(authenticationRequest);

                    token = response.AuthenticationResult.IdToken;
                }
            }
            catch (Exception exceptionObject)
            {
                throw exceptionObject;
            }

            return Ok(token);
        }
    }
}
