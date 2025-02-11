﻿

using ESPERILLA.UseCases.DTOs;
using ESPERILLA.UseCases.OutputPort;
using System.Net;

namespace ESPERILLA.Presenters;

public class CreatePatientPresenter : ICreatePatientOutputPort
{
   public CreatePatientPresenter()
   {

   }
    public bool IsSuccess
    {
        get { return Messages is null; }
    }
    public string? Data { get; set; }
    public IEnumerable<MessageDto?> Messages { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }

    public Task HandleFailure(IHandleFailure failure)
    {
        Messages = failure.Messages;
        HttpStatusCode = failure.HttpStatusCode;
        return Task.CompletedTask;
    }

    public Task HandleSuccess(IHandleSuccess<string> success)
    {
        Data = success.Data;
        HttpStatusCode = success.HttpStatusCode;
        return Task.CompletedTask;
    }
}
