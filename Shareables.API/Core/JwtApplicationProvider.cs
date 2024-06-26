﻿using Application;
using Application.DTO.Workspace;
using Domain;
using Implementation;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Shareables.API.Core
{
    public class JwtApplicationActorProvider : IApplicationActorProvider
    {
        private string authorizationHeader;

        public JwtApplicationActorProvider(string authorizationHeader)
        {
            this.authorizationHeader = authorizationHeader;
        }

        public IApplicationActor GetActor()
        {
            if (authorizationHeader.Split("Bearer ").Length != 2)
            {
                return new UnauthorizedActor();
            }

            string token = authorizationHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var actor = new Actor
            {
                Username = claims.First(x => x.Type == "Username").Value,
                Id = int.Parse(claims.First(x => x.Type == "Id").Value),
                WorkspacesUseCases = JsonConvert.DeserializeObject<List<WorkspaceUseCases>>(claims.First(x => x.Type == "Workspaces").Value)
            };

            return actor;
        }
    }

}
