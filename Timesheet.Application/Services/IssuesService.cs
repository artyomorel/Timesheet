using System;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.BussinessLogic.Services
{
    public class IssuesService : IIssuesService
    {
        private readonly IIssuesClient _client;

        public IssuesService(IIssuesClient client)
        {
            _client = client;
        }

        public Issue[] Get(string managerLogin,string projectName)
        {
            var issues = _client.Get(managerLogin,projectName).Result;
            return issues;
        }
    }
}
