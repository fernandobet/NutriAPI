﻿namespace NutriAPI.Errors
{
    public class CodeErrorResponse
    {
        //Aqui definimos la estructura que le devolveremos al clientes.
        public int StatusCode { get; set; }
        public string? Message { get; set; } = string.Empty;

        public CodeErrorResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch { 
                400 => "El request enviado tiene errores",
                401 => "No tienes autorizacion para este recurso",
                404 => "No se encontro el recurso solicitado",
                500 => "Se producieron errores en el servidor",
                _ => string.Empty,
            };
        }
    }
}
