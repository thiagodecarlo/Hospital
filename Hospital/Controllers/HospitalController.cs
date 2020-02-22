using AutoMapper;
using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private IHospitalRepository _HospitalRepo;
        private IMapper _mapper;

        public HospitalController(IHospitalRepository HospitalRepo, IMapper mapper)
        {
            _HospitalRepo = HospitalRepo;
            _mapper = mapper;
        }

        // GET: api/Hospital
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Hospitals = await _HospitalRepo.GetAllAsync();
                var HospitalsDTO = new List<Domain.Dtos.Hospital>();
                foreach (var h in Hospitals)
                {
                    HospitalsDTO.Add(new Domain.Dtos.Hospital()
                    {
                        Name = h.Name,
                        Address = h.Address,
                        CNPJ = h.CNPJ
                    });
                }
                return Ok(HospitalsDTO);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Hospital/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var HospitalDTO = _mapper.Map<Domain.Dtos.Hospital>(await _HospitalRepo.GetByIdAsync(Id));
                return Ok(HospitalDTO);
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Hospital
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Domain.Dtos.Hospital HospitalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Please check the Hospital data!" });
            try
            {
                var Hospital = _mapper.Map<Domain.Entities.Hospital>(HospitalDto);
                return Ok(_mapper.Map<Domain.Dtos.Hospital>(await _HospitalRepo.AddAsync(Hospital)));
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Hospital/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Domain.Dtos.Hospital HospitalDto)
        {
            try
            {
                var Hospital = _mapper.Map<Domain.Entities.Hospital>(HospitalDto);
                Hospital.Id = id;
                return Ok(_mapper.Map<Domain.Dtos.Hospital>(await _HospitalRepo.UpdateAsync(Hospital)));
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
                return Ok(await _HospitalRepo.RemoveAsync(id));
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
