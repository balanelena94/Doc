﻿using DocGenerator.Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.OAuth;
using ResidenceAdmin.DomainModel;
using ResidenceAdmin.Persistency;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DocGenerator.Api
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userStore = new UserStore<User>(new PersistencyContext());
            var manager = new UserManager<User>(userStore);
            var user = await manager.FindAsync(context.UserName, context.Password);
            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Username", user.UserName));
                identity.AddClaim(new Claim("Email", user.Email));
                identity.AddClaim(new Claim("FirstName", user.FirstName));
                identity.AddClaim(new Claim("LastName", user.LastName));
                identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                context.Validated(identity);
            }
            else
                return;
        }
    }
}