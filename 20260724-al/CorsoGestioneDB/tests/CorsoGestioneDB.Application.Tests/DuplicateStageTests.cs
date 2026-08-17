using CorsoGestioneDB.Application.Engine;
using CorsoGestioneDB.Application.Models;
using CorsoGestioneDB.Application.Pipeline;
using CorsoGestioneDB.Domain.Entities;
using Microsoft.Extensions.Logging.Abstractions;

namespace CorsoGestioneDB.Application.Tests;

public class DuplicateStageTests
{
    public static TheoryData<List<ImportContext>> DuplicateStageData =
    [
        [
            new ImportContext(new StagingOrder
            {
                OrderID = "  ORD00001 ",
                Email = " pippo@pluto.com   "
            }),
            new ImportContext(new StagingOrder
            {
                OrderID = "ORD00001    ",
                Email = "  PIPPO@PLUTO.COM "
            }),
        ]
    ];

    [Theory]
    [MemberData(nameof(DuplicateStageData))]
    public async Task DuplicateStage_Marks_Duplicate_Rows(IEnumerable<ImportContext> contexts)
    {
        var normalizeLogger = NullLogger<NormalizeStage>.Instance;
        var normalizeStage = new NormalizeStage(normalizeLogger);

        var duplicateLogger = NullLogger<DuplicateStage>.Instance;
        var duplicateStage = new DuplicateStage(duplicateLogger);

        await normalizeStage.ExecuteAsync(contexts);
        await duplicateStage.ExecuteAsync(contexts);

        var order1 = contexts.ElementAt(0);
        Assert.Equal("ORD00001", order1.RawOrder.OrderID);
        Assert.Equal(ImportRecordStatus.Pending, order1.Status);

        var order2 = contexts.ElementAt(1);
        Assert.Equal("ORD00001", order2.RawOrder.OrderID);
        Assert.Equal(ImportRecordStatus.Duplicate, order2.Status);
    }
}