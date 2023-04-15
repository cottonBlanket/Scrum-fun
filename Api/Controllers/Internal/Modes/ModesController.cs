using Api.Controllers.Base;
using Api.Controllers.Internal.Modes.dto.request;
using AutoMapper;
using Dal.Mode;
using Logic.Managers.Mode.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Internal.Modes;

[Route("mode")]
public class ModesController: BaseInternalController
{
    private readonly IMapper _mapper;
    private readonly IModeManager _modeManager;

    public ModesController(IMapper mapper, IModeManager modeManager)
    {
        _mapper = mapper;
        _modeManager = modeManager;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddMode(CreateModeRequest model)
    {
        var mode = _mapper.Map<ModeDal>(model);
        var id = await _modeManager.InsertAsync(mode);
        return Ok(id);
    }
}