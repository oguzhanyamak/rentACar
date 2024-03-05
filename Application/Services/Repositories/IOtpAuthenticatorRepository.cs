﻿using Core.Persistence.Repository;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IOtpAuthenticatorRepository : IAsyncRepository<OtpAuthenticator, int>{ }