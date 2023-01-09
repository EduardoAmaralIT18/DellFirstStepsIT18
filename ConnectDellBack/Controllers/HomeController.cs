using System.Runtime.Intrinsics.X86;
using System;
using System.Net;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConnectDellBack.Models;

namespace ConnectDellBack.Controllers;

public class HomeController : Controller
{
    private readonly ILogger _logService;
    public HomeController(ILogger logService)
    {
        _logService = logService;
    }

    [HttpGet("List")]
    public ActionResult GetAll()
    {
        List<ProgramModel> programs = new List<ProgramModel>();

        //mocks
        ProgramModel program1 = new ProgramModel();
        program1.name = "IT Academy";
        program1.description = "XYZ";
        programs.Add(program1);

        ProgramModel program2 = new ProgramModel();
        program1.name = "Design Academy";
        program1.description = "ABC";
        programs.Add(program2);

        ProgramModel program3 = new ProgramModel();
        program3.name = "Infrastructure Residency";
        program3.description = "WJK";
        programs.Add(program3);

        //var programs = programService.listProgram();
        return Ok(programs);
    }
}

