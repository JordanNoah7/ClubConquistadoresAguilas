﻿namespace Web.Models;

public class VmUser
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string CreationDate { get; set; }

    public VmRole Role { get; set; }
}