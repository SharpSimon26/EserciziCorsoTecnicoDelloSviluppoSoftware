using CorsoGestioneDB.Application.Engine;
using CorsoGestioneDB.Application.Models;
using CorsoGestioneDB.Application.Pipeline;
using CorsoGestioneDB.Domain.Entities;
using Microsoft.Extensions.Logging.Abstractions;

namespace CorsoGestioneDB.Application.Tests;

public class NormalizeStageTests
{
    public static TheoryData<List<ImportContext>> NormalizeStageData =
    [
        [
            new ImportContext(new StagingOrder
            {
                OrderID = "  ORD00001 ",
                Email = " pippo@pluto.com   "
            }),
            new ImportContext(new StagingOrder
            {
                OrderID = "ORD00002    ",
                Email = "  TOPOLINO@minnie.net "
            }),
        ]
    ];

    [Theory]
    [MemberData(nameof(NormalizeStageData))]
    public async Task NornalizeStage_Trims_Properties_And_Stuff(IEnumerable<ImportContext> contexts)
    {
        var logger = NullLogger<NormalizeStage>.Instance;
        var normalizeStage = new NormalizeStage(logger);
        await normalizeStage.ExecuteAsync(contexts);

        var order1 = contexts.ElementAt(0);
        Assert.Equal("ORD00001", order1.RawOrder.OrderID);
        Assert.Equal("pippo@pluto.com", order1.RawOrder.Email);
        Assert.Equal(ImportRecordStatus.Pending, order1.Status);
        Assert.Equal(2, order1.Messages.Count);

        var order2 = contexts.ElementAt(1);
        Assert.Equal("ORD00002", order2.RawOrder.OrderID);
        Assert.Equal("topolino@minnie.net", order2.RawOrder.Email);
        Assert.Equal(ImportRecordStatus.Pending, order2.Status);
        Assert.Equal(2, order2.Messages.Count);
    }
}