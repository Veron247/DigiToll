using System.Security.Claims;
using Authentication.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Authentication.API.Factory;

 public class CustomAuthorizationAttribute : TypeFilterAttribute
 {
     public CustomAuthorizationAttribute(string claimType = "", string claimValue = "") : base(typeof(CustomAuthorizationFilter))
     {
         Arguments = new object[] { new Claim(claimType, claimValue) };
     }
 }

 public class CustomAuthorizationFilter : IAuthorizationFilter
 {
     readonly Claim _claim;

     public CustomAuthorizationFilter(Claim claim)
     {
         _claim = claim;
     }

     public void OnAuthorization(AuthorizationFilterContext context)
     {
         var claimValues = string.IsNullOrEmpty(_claim.Value) ? new List<string>() : _claim.Value.Split(",").ToList();
         var sessionUserId = context.HttpContext.Session.GetString(SessionData.SessionUserID);
         var sessionIpAddress = context.HttpContext.Session.GetString(SessionData.SessionKeyIpAddress);
         var userAuthenticated = context.HttpContext?.User?.Identity?.IsAuthenticated;
         var contextIpAddress = context.HttpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString();


         if (string.IsNullOrEmpty(sessionUserId) || userAuthenticated == false || sessionIpAddress != contextIpAddress)
         {
             context.Result = new ForbidResult();
         }

         if (claimValues.Count > 0)
         {
             var hasClaim = context.HttpContext?.User.Claims.Any(c => c.Type == _claim.Type && claimValues.Contains(c.Value));
             if (hasClaim == false)
             {
                 context.Result = new ForbidResult();
             }
         }
     }
 }
