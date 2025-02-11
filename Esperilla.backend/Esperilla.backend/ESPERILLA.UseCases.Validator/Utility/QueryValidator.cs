using ESPERILLA.UseCases.DTOs;
namespace ESPERILLA.UseCases.Validator;

public class QueryValidator
{
    public static List<MessageDto> Validate(GetQueryDto queryDto)
    {
        var result = new List<MessageDto>();

        if (queryDto.Page <= 0) result.Add(new MessageDto("La pagina actual tiene que ser mayor a cero"));
        if (queryDto.PageSize <= 0) result.Add(new MessageDto("La cantidad de paginas tiene que ser mayor a cero"));

        return result;
    }

}
