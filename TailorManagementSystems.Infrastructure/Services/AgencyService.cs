using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.DTO.Agency;
using TailorManagementSystems.Application.DTO.Customers;
using TailorManagementSystems.Application.Interfaces.Agency;
using TailorManagementSystems.Application.Models.Agency;
using TailorManagementSystems.Infrastructure.Persistence.Scaffold;

namespace TailorManagementSystems.Infrastructure.Services
{
    public class AgencyService : IAgency
    {
        private readonly AppDbContext _context;
        public AgencyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> CreateAsync(AgencyModel agency)
        {
            if (string.IsNullOrWhiteSpace(agency.Name))
                return Response<bool>.Fail("Agency name canot be empty!");

            var entity = new Agency
            {
                Name = agency.Name,
                Description = agency.Description,
                StartDate = agency.StartDate,
                TargetDate = agency.TargetDate,
                RowStatus = 1
            };

            _context.Agencies.Add(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Create Agency successfully!");
        }

        public async Task<Response<bool>> DeleteAsync(int Id)
        {
            var entity = await _context.Agencies.FindAsync(Id);
            if (entity == null)
                return Response<bool>.Fail("Agency not found!");

            _context.Agencies.Remove(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Delete agency sucessfully!");
        }

        public async Task<Response<PagedResult<AgencyDTO>>> GetAllAsync(PagedRequest request)
        {
            var query = _context.Agencies.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var keyword = request.Search.Trim();
                query = query.Where(c =>
                    c.Name.Contains(keyword) &&
                    c.RowStatus == 1);
            }

            var totalItems = await query.CountAsync();
            var agencies = await query.OrderBy(c => c.Name).Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new AgencyDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    StartDate = c.StartDate,
                    TargetDate = c.TargetDate,
                    RowStatus = c.RowStatus
                })
            .ToListAsync();

            var result = new PagedResult<AgencyDTO>
            {
                Items = agencies,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };

            return Response<PagedResult<AgencyDTO>>.Ok(result);
        }

        public async Task<Response<AgencyDTO?>> GetByIdAsync(int Id)
        {
            var entity = await _context.Agencies.FindAsync(Id);
            if (entity == null)
                return Response<AgencyDTO?>.Fail("Agency tidak ditemukan");

            return Response<AgencyDTO?>.Ok(new AgencyDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                StartDate = entity.StartDate,
                TargetDate = entity.TargetDate,
                RowStatus = entity.RowStatus
            });
        }

        public async Task<Response<bool>> UpdateAsync(int Id, AgencyModel agency)
        {
            var entity = await _context.Agencies.FindAsync(agency.Id);
            if (entity == null)
                return Response<bool>.Fail("Agency tidak ditemukan");

            entity.Name = agency.Name;
            entity.Description = agency.Description;
            entity.RowStatus = agency.RowStatus;
            entity.StartDate = agency.StartDate;
            entity.TargetDate = agency.TargetDate;
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Update customer successfully!");
        }
    }
}
