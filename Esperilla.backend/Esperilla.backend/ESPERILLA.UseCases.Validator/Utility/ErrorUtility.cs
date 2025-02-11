
using ESPERILLA.UseCases.DTOs;

namespace ESPERILLA.UseCases.Validator;

public class ErrorUtility
{
    private static readonly Dictionary<string, string> Errors = new Dictionary<string, string>()
 {
     {"0001", "YA EXISTE UN PACIENTE CON EL MISMO NUMERO DE TELEFONO"},
     {"0002", "NO EXISTE EL PACIENTE CON ESE ID"},
     {"0003", "EL FORMATO DE FECHA A INGRESAR ES YYYY-MM-DD"},


 };

    public static MessageDto CreateFromCode(string errorCode)
    {

        if (!Errors.ContainsKey(errorCode)) return new MessageDto(code: "0000", description: "ERROR SIN CLASIFICAR");

        return new MessageDto(code: errorCode, description: Errors[errorCode].ToUpper());
    }
    public static MessageDto CreateFromCode(string errorCode, params object[] args)
    {
        if (string.IsNullOrWhiteSpace(errorCode))
            return new MessageDto(code: "0000", description: "CÓDIGO DE ERROR INVÁLIDO");

        if (!Errors.ContainsKey(errorCode))
            return new MessageDto(code: "0000", description: "ERROR SIN CLASIFICAR");
        string baseMessage = Errors[errorCode];
        string formattedMessage = args.Length > 0
            ? string.Format(baseMessage, args)
            : baseMessage;

        return new MessageDto(code: errorCode, description: formattedMessage.ToUpper());
    }
}
