﻿namespace EmailNotifier.Application.Models;

public class Auth
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}