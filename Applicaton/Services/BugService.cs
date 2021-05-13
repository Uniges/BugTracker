using BugTracker.Applicaton.Contracts;
using BugTracker.Applicaton.Models;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BugTracker.Applicaton.Services
{
    public class BugService : IBugService
    {
        private readonly IRepository<Bug> _bugRepository;
        private readonly IRepository<BugHistory> _bugHistoryRepository;

        public BugService(IRepository<Bug> bugRepository, IRepository<BugHistory> bugHistoryRepository)
        {
            _bugRepository = bugRepository;
            _bugHistoryRepository = bugHistoryRepository;
        }

        public async Task<IEnumerable<Bug>> GetAllAsync()
        {
            return await _bugRepository.GetAllAsync();
        }

        public async Task<Bug> GetByIdAsync(int id)
        {
            var bug = await _bugRepository.GetByIdAsync(id);
            return bug;
        }

        private async Task AddAsync(Bug entity)
        {
            await _bugRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Bug entity)
        {
            await _bugRepository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<Bug>> GetAllSortedAsync(BugSortRequest entity)
        {
            var bugs = await _bugRepository.GetAllAsync();

            var sortedResult = entity.IsSortByDesc ? bugs.OrderByDescending(e => e.Date) : bugs.OrderBy(e => e.Date);

            switch (entity.FieldName.ToLower())
            {

                case "title":
                    sortedResult = entity.IsSortByDesc ? bugs.OrderByDescending(e => e.Title) : bugs.OrderBy(e => e.Title);
                    break;

                case "date":
                    sortedResult = entity.IsSortByDesc ? bugs.OrderByDescending(e => e.Date) : bugs.OrderBy(e => e.Date);
                    break;

                case "status":
                    sortedResult = entity.IsSortByDesc ? bugs.OrderByDescending(e => e.Status) : bugs.OrderBy(e => e.Status);
                    break;

                case "urgency":
                    sortedResult = entity.IsSortByDesc ? bugs.OrderByDescending(e => e.Urgency) : bugs.OrderBy(e => e.Urgency);
                    break;

                case "criticality":
                    sortedResult = entity.IsSortByDesc ? bugs.OrderByDescending(e => e.Criticality) : bugs.OrderBy(e => e.Criticality);
                    break;

                default:
                    sortedResult = entity.IsSortByDesc ? bugs.OrderByDescending(e => e.Id) : bugs.OrderBy(e => e.Id);
                    break;
            }

            return sortedResult;
        }

        public async Task CreateByUserAsync(BugRequest bugRequest, int userId)
        {
            Bug bug = new Bug();
            bug.UserId = userId;
            bug.Title = bugRequest.Title;
            bug.Description = bugRequest.Description;
            bug.Status = bugRequest.Status;
            bug.Urgency = bugRequest.Urgency;
            bug.Criticality = bugRequest.Criticality;

            await AddAsync(bug);
            //BugHistory bugHistory = new BugHistory();
            //bugHistory.BugId
        }
    }
}
