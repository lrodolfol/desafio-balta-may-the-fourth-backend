﻿using Microsoft.AspNetCore.Mvc;
using StarLs.Application.Queries.Characters;
using StarLs.Core.Handlers.Interface;

namespace StarLs.Api.Endpoints
{
    public static class CharacterEndpoints
    {
        public static void MapCharacterRoutes(this WebApplication app)
        {
            app.MapGet("/characters", async ([FromServices] IHandler<GetCharacterQueryRequest, List<GetCharacterQueryResponse>> handler) =>
            {
                var result = await handler.Send(new GetCharacterQueryRequest());
                return Results.Ok(result);
            })
            .WithTags("Character");

            app.MapGet("/characters/{id}", async ([FromServices] IHandler<GetCharacterByIdQueryRequest, GetCharacterByIdQueryResponse> handler, [FromRoute] short id) =>
            {
                var result = await handler.Send(new GetCharacterByIdQueryRequest(id));
                return Results.Ok(result);
            })
            .WithTags("Character");
        }
    }
}
