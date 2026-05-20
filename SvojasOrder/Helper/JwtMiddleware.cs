using SvojasOrder.Models;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SvojasOrder.Helper
{
    class JwtMiddleware
    {
        private readonly RequestDelegate _next;
       
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }
        public async Task Invoke(HttpContext context, JwtSettings jwtSettings)
        {
           
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
                //Validate the token
                attachUserToContext(context, token, jwtSettings);
            await _next(context);
        }
        private  void attachUserToContext(HttpContext context, string token, JwtSettings jwtSettings)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.IssuerSigningKey)),
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = jwtSettings.ValidAudience,
                    RequireExpirationTime = jwtSettings.RequireExpirationTime,
                    ValidateLifetime = jwtSettings.RequireExpirationTime,
                    ClockSkew = TimeSpan.Zero,
                };

                string userId = "";
                string username = "";
                try
                {
                    tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                    var jwtToken = (JwtSecurityToken)validatedToken;
                    userId = Convert.ToString(jwtToken.Claims.First(x => x.Type == "Id").Value);
                    username = Convert.ToString(jwtToken.Claims.First(x => x.Type == "name").Value);
                }
                catch(Exception)
                {

                }
                    // attach user to context on successful jwt validation
                // context.Items["User"] = userService.GetById(userId);
               
                if(userId=="" || userId==null)
                {
                    context.Items["User"] = null;
                }
                else
                {
                    context.Items["User"] = userId;
                }
            }
            catch (Exception)
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }

    }

   

}
