using CorsoGestioneDB.Application.Engine;
using CorsoGestioneDB.Application.Models;
using CorsoGestioneDB.Application.Pipeline;
using CorsoGestioneDB.Domain.Entities;
using Microsoft.Extensions.Logging.Abstractions;

namespace CorsoGestioneDB.Application.Tests;

public class ConvertStageTests
{
    public static TheoryData<List<ImportContext>> ConvertStageData =
    [
        [
            new ImportContext(new StagingOrder
            {
                OrderID = "  ORD00001 ",
                Email = " pippo@pluto.com   ",
                Quantity = " 5",
                UnitPrice = "113.75",
                DiscountPct = "0 "
            }),
            new ImportContext(new StagingOrder
            {
                OrderID = "ORD00002    ",
                Email = "  TOPOLINO@MINNIE.net ",
                Quantity = "2 ",
                UnitPrice = " 11.43",
                DiscountPct = "   10 "
            }),
        ]
    ];

    [Theory]
    [MemberData(nameof(ConvertStageData))]
    public async Task ConvertStage_Converts_Values_And_Populates_Data(IEnumerable<ImportContext> contexts)
    {
        var normalizeLogger = NullLogger<NormalizeStage>.Instance;
        var normalizeStage = new NormalizeStage(normalizeLogger);

        var duplicateLogger = NullLogger<DuplicateStage>.Instance;
        var duplicateStage = new DuplicateStage(duplicateLogger);

        var convertLogger = NullLogger<ConvertStage>.Instance;
        var convertStage = new ConvertStage(convertLogger);

        await normalizeStage.ExecuteAsync(contexts);
        await duplicateStage.ExecuteAsync(contexts);
        await convertStage.ExecuteAsync(contexts);

        var order1 = contexts.ElementAt(0);
        Assert.Equal(5, order1.Data.OrderLine.Quantity);
        Assert.Equal(113.75m, order1.Data.OrderLine.UnitPrice);

        var order2 = contexts.ElementAt(1);
        Assert.Equal(2, order2.Data.OrderLine.Quantity);
        Assert.Equal(11.43m, order2.Data.OrderLine.UnitPrice);
    }
}