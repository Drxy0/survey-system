﻿namespace SurveySystem.Api.Controllers.Users;

public sealed record LoginRequest(
    string Email,
    string Password
);
