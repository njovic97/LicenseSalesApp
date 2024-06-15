public class CodeRepository : ICodeRepository
{
    private readonly DataContext _context;

    public CodeRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Code>> GetCodesAsync()
    {
        return await _context.Codes.ToListAsync();
    }

    public async Task<Code> AddCodeAsync(Code code)
    {
        await _context.Codes.AddAsync(code);
        await _context.SaveChangesAsync();
        return code;
    }

    public async Task<Code> GetCodeByIdAsync(int codeId)
    {
        return await _context.Codes.FindAsync(codeId);
    }

    public async Task UpdateCodeAsync(Code code)
    {
        _context.Codes.Update(code);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCodeAsync(Code code)
    {
        _context.Codes.Remove(code);
        await _context.SaveChangesAsync();
    }
}
