public interface ICodeRepository
{
    Task<List<Code>> GetCodesAsync();
    Task<Code> AddCodeAsync(Code code);
    Task<Code> GetCodeByIdAsync(int codeId);
    Task UpdateCodeAsync(Code code);
    Task DeleteCodeAsync(Code code);
}
