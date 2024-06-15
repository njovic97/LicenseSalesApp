public class CodeService : ICodeService
{
    private readonly ICodeRepository _codeRepository;

    public CodeService(ICodeRepository codeRepository)
    {
        _codeRepository = codeRepository;
    }

    public async Task<ServiceResponse<List<Code>>> GetCodesAsync()
    {
        var codes = await _codeRepository.GetCodesAsync();
        return new ServiceResponse<List<Code>> { Success = true, Data = codes };
    }

    public async Task<ServiceResponse<Code>> AddCodeAsync(CodeDto codeDto)
    {
        var code = new Code
        {
            VendorId = codeDto.VendorId,
            CodeValue = codeDto.CodeValue,
            Category = codeDto.Category,
            ValidFrom = codeDto.ValidFrom,
            ValidTo = codeDto.ValidTo,
            Price = codeDto.Price,
            Image = codeDto.Image,
            IsSublicensed = codeDto.IsSublicensed,
            IsGroupCode = codeDto.IsGroupCode
        };

        var createdCode = await _codeRepository.AddCodeAsync(code);
        return new ServiceResponse<Code> { Success = true, Data = createdCode };
    }

    public async Task<ServiceResponse<Code>> UpdateCodeAsync(int codeId, CodeDto codeDto)
    {
        var code = await _codeRepository.GetCodeByIdAsync(codeId);
        if (code == null)
        {
            return new ServiceResponse<Code> { Success = false, Message = "Code not found." };
        }

        code.VendorId = codeDto.VendorId;
        code.CodeValue = codeDto.CodeValue;
        code.Category = codeDto.Category;
        code.ValidFrom = codeDto.ValidFrom;
        code.ValidTo = codeDto.ValidTo;
        code.Price = codeDto.Price;
        code.Image = codeDto.Image;
        code.IsSublicensed = codeDto.IsSublicensed;
        code.IsGroupCode = codeDto.IsGroupCode;

        await _codeRepository.UpdateCodeAsync(code);
        return new ServiceResponse<Code> { Success = true, Data = code };
    }

    public async Task<ServiceResponse<bool>> DeleteCodeAsync(int codeId)
    {
        var code = await _codeRepository.GetCodeByIdAsync(codeId);
        if (code == null)
        {
            return new ServiceResponse<bool> { Success = false, Message = "Code not found." };
        }

        await _codeRepository.DeleteCodeAsync(code);
        return new ServiceResponse<bool> { Success = true, Data = true };
    }
}
