using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieManager.Utilities
{
    public class JwtAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var key = Encoding.ASCII.GetBytes(appSettings["Jwt:Secret"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // Check if the user is authorized to access the resource
                //if (!string.IsNullOrEmpty(Roles) && !jwtToken.Claims.Any(x => x.Type == ClaimTypes.Role && Roles.Split(",").Contains(x.Value)))
                //{
                //    context.Result = new Microsoft.AspNetCore.Mvc.ForbidResult();
                //    return;
                //}

                // Add user id to the HttpContext so it can be accessed by the controller
                context.HttpContext.Items["UserId"] = userId;
            }
            catch
            {
                context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
                return;
            }
        }
    }
}

