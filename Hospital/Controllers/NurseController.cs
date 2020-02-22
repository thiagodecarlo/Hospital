using AutoMapper;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NurseController : ControllerBase
    {
        private INurseRepository _nurseRepo;
        private IMapper _mapper;

        public NurseController(INurseRepository NurseRepo, IMapper mapper)
        {
            _nurseRepo = NurseRepo;
            _mapper = mapper;
        }

        // GET: api/Nurse
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Nurses = await _nurseRepo.GetAllAsync();
                var NursesDTO = new List<Domain.Dtos.Nurse>();
                foreach (Nurse n in Nurses)
                {
                    NursesDTO.Add(new Domain.Dtos.Nurse()
                    {
                        BirthDate = n.BirthDate,
                        COREN = n.COREN,
                        CPF = n.CPF,
                        HospitalId = n.HospitalId,
                        Id = n.Id,
                        Name = n.Name
                    });
                }
                return Ok(NursesDTO);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Nurse/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var NurseDTO = _mapper.Map<Domain.Dtos.Nurse>(await _nurseRepo.GetByIdAsync(Id));
                return Ok(NurseDTO);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Nurse
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Domain.Dtos.Nurse NurseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Please check the Nurse data!" });
            try
            {
                var Nurse = _mapper.Map<Domain.Entities.Nurse>(NurseDto);
                return Ok(_mapper.Map<Domain.Dtos.Nurse>(await _nurseRepo.AddAsync(Nurse)));
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Nurse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Domain.Dtos.Nurse NurseDto)
        {
            try
            {
                var Nurse = _mapper.Map<Nurse>(NurseDto);
                Nurse.Id = id;
                return Ok(_mapper.Map<Domain.Dtos.Nurse>(await _nurseRepo.UpdateAsync(Nurse)));
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _nurseRepo.RemoveAsync(id));
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
