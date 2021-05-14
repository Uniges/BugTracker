using BugTracker.Applicaton.Contracts;
using BugTracker.Applicaton.Models;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using BugTracker.Domain.Enums;
using BugTracker.Applicaton.Exceptions;
using BugTracker.DAL.Repository;
using AutoMapper;
using BugTracker.Applicaton.Helpers;

namespace BugTracker.Applicaton.Services
{
    public class BugService : IBugService
    {
        private readonly IRepository<Bug> _bugRepository;
        private readonly IRepository<BugHistory> _bugHistoryRepository;
        private readonly IMapper _mapper;

        public BugService(IRepository<Bug> bugRepository, IRepository<BugHistory> bugHistoryRepository, IMapper mapper)
        {
            _bugRepository = bugRepository;
            _bugHistoryRepository = bugHistoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Bug>> GetAllAsync()
        {
            return await _bugRepository.GetAllAsync();
        }

        public async Task<Bug> GetByIdAsync(int id)
        {
            var bug = await _bugRepository.GetByIdAsync(id);
            if (bug == null) throw new BugNotFoundException();
            return bug;
        }

        private async Task AddAsync(Bug entity)
        {
            await _bugRepository.AddAsync(entity);
        }

        private async Task UpdateAsync(Bug entity)
        {
            await _bugRepository.UpdateAsync(entity);
        }

        public async Task<IEnumerable<Bug>> GetAllSortedAsync(BugSortRequest entity)
        {
            var bugs = await _bugRepository.GetAllAsync();

            if (typeof(Bug).GetProperty(entity.FieldName) == null) throw new BugInputPropertyException();

            return entity.IsSortByDesc ?
                bugs.OrderBy(entity.FieldName) :
                bugs.OrderByDescending(entity.FieldName);
        }

        public async Task CreateByUserAsync(BugInputRequest bugRequest, int userId)
        {
            var bug = _mapper.Map<Bug>(bugRequest);
            bug.UserId = userId;
            bug.Status = BugStatus.New;
            await AddAsync(bug);

            BugHistory bugHistory = new BugHistory();
            bugHistory.BugId = bug.Id;
            bugHistory.Action = BugAction.Input;
            bugHistory.Comment = bugRequest.Comment;
            await _bugHistoryRepository.AddAsync(bugHistory);
        }

        public async Task UpdateByUserAsync(BugUpdateRequest bugUpdateRequest)
        {
            var bug = await GetByIdAsync(bugUpdateRequest.BugId);
            BugStatus currentStatus = bug.Status;
            BugStatus newStatus = bugUpdateRequest.BugStatus;

            bool isTransferPossible =
                (currentStatus == BugStatus.New && newStatus == BugStatus.Opened) ||
                (currentStatus == BugStatus.Opened && newStatus == BugStatus.Fixed) ||
                (currentStatus == BugStatus.Fixed && newStatus == BugStatus.Opened) ||
                (currentStatus == BugStatus.Fixed && newStatus == BugStatus.Closed);
            if (!isTransferPossible) throw new BugUpdateException();

            bug.Status = bugUpdateRequest.BugStatus;
            await UpdateAsync(bug);

            BugHistory bugHistory = new BugHistory();
            bugHistory.BugId = bug.Id;
            switch (bugUpdateRequest.BugStatus)
            {
                case BugStatus.Opened:
                    bugHistory.Action = BugAction.Open;
                    break;
                case BugStatus.Fixed:
                    bugHistory.Action = BugAction.Solution;
                    break;
                case BugStatus.Closed:
                    bugHistory.Action = BugAction.Close;
                    break;
            }
            bugHistory.Comment = bugUpdateRequest.Comment;
            await _bugHistoryRepository.AddAsync(bugHistory);
        }

        public async Task<ICollection<BugHistory>> GetBugHistoryAsync(int id)
        {
            var bugHistory = await (_bugRepository as BugRepository).GetBugHistoryAsync(id);
            if (bugHistory == null) throw new BugNotFoundException();
            return bugHistory;
        }
    }
}
