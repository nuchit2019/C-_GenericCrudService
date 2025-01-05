using GenericCrudService.Model;
using GenericCrudService.Service;
using Microsoft.AspNetCore.Mvc;

namespace GenericCrudService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IGenericCrudService<Customer> _service;

        public CustomersController(IGenericCrudService<Customer> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return customer;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create(Customer customer)
        {
            var createdCustomer = await _service.CreateAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            if (id != customer.Id) return BadRequest();
            await _service.UpdateAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
