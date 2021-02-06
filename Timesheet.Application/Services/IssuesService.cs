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

        public Issue[] Get(string loginManager,string projectName)
        {
            var issues = _client.Get(loginManager,projectName).Result;
            return issues;
        }


    }
}
