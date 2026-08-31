namespace JsonPlaceholder.Api.Models;

public class Operazione
{
    public string Op { get; set; } = string.Empty;
    public decimal Parametro1 { get; set; }
    public decimal Parametro2 { get; set; }

    public decimal Execute()
    {
        decimal risultato;

        switch (Op)
        {
            case "somma":
                risultato = Parametro1 + Parametro2;
                break;

            case "sottrazione":
                risultato = Parametro1 - Parametro2;
                break;

            case "moltiplicazione":
                risultato = Parametro1 * Parametro2;
                break;

            case "divisione":
                risultato = Parametro1 / Parametro2;
                break;

            default:
                throw new InvalidOperationException("Operazione sconosciuta");
        }

        return risultato;
    }
}
