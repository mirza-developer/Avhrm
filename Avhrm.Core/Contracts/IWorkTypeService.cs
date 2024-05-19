﻿using Avhrm.Core.Features.WorkType.Query.GetAllWorkTypes;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IWorkTypeService
{
    Task<List<GetAllWorkTypesVm>> GetWorkTypesByDepartmentId(CallContext context = default);
}
