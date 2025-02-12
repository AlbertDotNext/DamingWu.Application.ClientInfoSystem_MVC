﻿using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CurrentEmployee : ICurrentEmployee
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentEmployee(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public int EmployeeId => Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public string Name => _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

        public bool IsAdmin => throw new NotImplementedException();

        public bool IsSuperAdmin => throw new NotImplementedException();
    }
}
