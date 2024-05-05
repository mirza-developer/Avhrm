﻿using Avhrm.Core.Common;
using Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;
using Avhrm.Core.Features.WorkingReport.Query.GetWorkReportById;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Core.Contracts;

[Service]
public interface IWorkReportService
{
    Task<List<WorkReport>> GetWorkingReportByDate(GetUserWorkingReportByDateQuery query, CallContext context = default);
    Task<WorkReport> GetWorkReportById(GetWorkReportByIdQuery query, CallContext context = default);
    Task<BaseDto<bool>> InsertWorkReport(WorkReport workReport, CallContext context = default);
    Task<BaseDto<bool>> UpdateWorkReport(WorkReport workReport, CallContext context = default);
    Task<BaseDto<bool>> DeleteWorkReport(WorkReport workReport, CallContext context = default);
}
