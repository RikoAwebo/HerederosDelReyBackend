using AutoMapper;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

public class ClienteService : IClienteService
{
    private readonly IGenericRepository<Cliente> _repo;
    private readonly IMapper _mapper;

    public ClienteService(IGenericRepository<Cliente> repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var clientes = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
    }

    public async Task<ClienteDto?> GetByIdAsync(int id)
    {
        var cliente = await _repo.GetByIdAsync(id);
        return cliente == null ? null : _mapper.Map<ClienteDto>(cliente);
    }

    public async Task<ClienteDto> AddAsync(ClienteCreateDto dto)
    {
        var cliente = _mapper.Map<Cliente>(dto);

        await _repo.AddAsync(cliente);

        return _mapper.Map<ClienteDto>(cliente);
    }

    public async Task<bool> UpdateAsync(int id, ClienteUpdateDto dto)
    {
        var cliente = await _repo.GetByIdAsync(id);

        if (cliente == null)
            return false;

        _mapper.Map(dto, cliente);

        _repo.Update(cliente);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cliente = await _repo.GetByIdAsync(id);

        if (cliente == null)
            return false;

        await _repo.DeleteAsync(id);

        return true;
    }
}