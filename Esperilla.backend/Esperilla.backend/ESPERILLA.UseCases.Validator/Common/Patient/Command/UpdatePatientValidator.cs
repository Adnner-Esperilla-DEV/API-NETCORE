
using ESPERILLA.UseCases.DTOs.Input;
using ESPERILLA.UseCases.DTOs;
using ESPERILLA.UseCases.Interface;
using System.Linq;
using System.Net;
using ESPERILLA.UseCases.Input;
using ESPERILLA.UseCases.InputPort;
using ESPERILLA.Entities.Utility;

namespace ESPERILLA.UseCases.Validator
{
    public class UpdatePatientValidator : IInputPortValidator<UpdatePatientDto>
    {
        private readonly IPatientRepository _patientRepository;
        public UpdatePatientValidator(
            IPatientRepository patientRepository
            )
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<MessageDto?> Messages { get; set; } = [];
        public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.UnprocessableEntity;

        public async Task<bool> IsValid(UpdatePatientDto inputDto)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByIdAsync(patientId: inputDto.getPatientId());
                if (patient is null)
                    Messages = Messages.Concat([ErrorUtility.CreateFromCode(errorCode: "0002")]);

                if (String.IsNullOrEmpty(inputDto.Name))
                    Messages = Messages.Concat([ErrorUtility.CreateFromCode(errorCode: "0001")]);

                if (String.IsNullOrEmpty(inputDto.LastName))
                    Messages = Messages.Concat([ErrorUtility.CreateFromCode(errorCode: "0001")]);

                if (String.IsNullOrEmpty(inputDto.BirthDate))
                    Messages = Messages.Concat([ErrorUtility.CreateFromCode(errorCode: "0003")]);

                bool resp = DateUtility.ValidateDate(inputDto.BirthDate);
                
                if (!resp)
                    Messages = Messages.Concat([ErrorUtility.CreateFromCode(errorCode: "0003")]);
                return Messages.ToList().Count == 0;
            }
            catch (Exception ex)
            {
                HttpStatusCode = HttpStatusCode.InternalServerError;
                Messages = [new MessageDto(String.Format("Ocurrio un error en el momento validar el servicio: {0}", ex.Message))];
                return false;
            }
        }
    }
}
