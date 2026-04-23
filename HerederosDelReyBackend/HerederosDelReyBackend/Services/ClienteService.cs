using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

public class ClienteService : IClienteService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ClienteService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<ClienteDto> AddAsync(ClienteCreateDto dto)
    {
        var Objeto = _mapper.Map<Cliente>(dto);

        await _unitOfWork.Clientes.AddAsync(Objeto);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<ClienteDto>(Objeto);
    }

    public async Task<bool> DeleteAsync(int id)
    {

        var objeto = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (objeto == null)
            return false;

        await _unitOfWork.Clientes.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ClienteDto>> GetAllAsync()
    {
        var lista = await _unitOfWork.Clientes.GetAllAsync();
        return _mapper.Map<IEnumerable<ClienteDto>>(lista);
    }

    public async Task<ClienteDto?> GetByIdAsync(int id)
    {
        var objeto = await _unitOfWork.Clientes.GetByIdAsync(id);
        if (objeto == null)
            return null;

        return _mapper.Map<ClienteDto>(objeto);
    }

    public async Task<bool> UpdateAsync(int id, ClienteUpdateDto dto)
    {
        if (id == null)
            return false;

        var Cliente = _unitOfWork.Clientes.GetByIdAsync(id).Result;
        if (Cliente == null)
            return false;

        Cliente.Nombre = dto.Nombre;
        Cliente.Telefono = dto.Telefono;
        Cliente.Email = dto.Email;
        Cliente.Direccion = dto.Direccion;


        _unitOfWork.Clientes.Update(Cliente);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<ApiResponse<IEnumerable<ClienteDto>>> GetAllAsync(PostQueryFilter filter)
    {
        var objeto = await _unitOfWork.Clientes.GetAllAsync(filter);
        var objetoDto = _mapper.Map<IEnumerable<ClienteDto>>(objeto);

        return new ApiResponse<IEnumerable<ClienteDto>>(objetoDto, objeto.MetaData);
    }
}