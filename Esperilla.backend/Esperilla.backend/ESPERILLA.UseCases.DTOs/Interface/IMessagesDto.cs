﻿

namespace ESPERILLA.UseCases.DTOs.Interface;

public interface IMessagesDto
{
    public IEnumerable<MessageDto?> Messages { get; set; }
}
