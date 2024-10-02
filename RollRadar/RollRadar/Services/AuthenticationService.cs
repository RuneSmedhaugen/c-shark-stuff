using System;
using RollRadar.Models;

public class AuthenticationService
{
    private readonly UserService _userService;

    public AuthenticationService(UserService userService)
    {
        _userService = userService;
    }

    public Users Login(string email, string password)
    {
        Users user = _userService.GetByEmail(email);
        if (user != null && VerifyPassword(password, user.PasswordHash))
        {
            return user;
        }
        return null;
    }

    private bool VerifyPassword(string inputPassword, string hashedPassword)
    {
        string inputHash = _userService.HashPassword(inputPassword);
        return inputHash == hashedPassword;
    }
}