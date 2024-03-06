﻿using Avhrm.Core.Common;
using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;
using System.Collections.Generic;

namespace Avhrm.Persistence.Repositories;

[Authorize]
public class VacationRequestService : IVacationRequest
{
    private readonly AvhrmDbContext dbContext;
    private DbSet<VacationRequest> dbSet;
    public VacationRequestService(AvhrmDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = this.dbContext.VacationRequests;
    }

    public async Task<BaseDto<bool>> InsertVacationRequest(VacationRequest request, CallContext context = default)
    {
        try
        {
            request.IsVerified = false;

            request.CreateDateTime = DateTime.Now;

            request.CreatorUser = context.GetUserId();

            await dbSet.AddAsync(request);

            return new()
            {
                Value = await dbContext.SaveChangesAsync() > 0
            };
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<List<VacationRequest>> GetVacationRequests(CallContext context = default)
    => await dbSet.Where(p => p.CreatorUser == context.GetUserId()).AsNoTracking().ToListAsync();

    public async Task<VacationRequest> GetVacationRequestById(BaseDto<int> id, CallContext context = default)
    => await dbSet.FirstOrDefaultAsync(p => p.CreatorUser == context.GetUserId() && p.Id == id.Value);

    public async Task<BaseDto<bool>> UpdateVacationRequest(VacationRequest request, CallContext context = default)
    {
        request.LastUpdateDateTime = DateTime.Now;

        request.LastUpdateUser = context.GetUserId();

        dbSet.Update(request);

        return new()
        {
            Value = await dbContext.SaveChangesAsync() > 0
        };
    }

    public async Task<BaseDto<bool>> DeleteVacationRequest(VacationRequest request, CallContext context = default)
    {
        dbSet.Remove(request);

        return new()
        {
            Value = await dbContext.SaveChangesAsync() > 0
        };
    }
}
