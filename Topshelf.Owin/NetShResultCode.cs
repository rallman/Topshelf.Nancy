﻿/*
Copied from justeat/Topshelf.Nancy
*/
namespace Topshelf.Owin
{
    public enum NetShResultCode
    {
        Error = -1,
        Success = 0,
        UrlReservationAlreadyExists = 183,
        UrlReservationDoesNotExist = 2
    }
}